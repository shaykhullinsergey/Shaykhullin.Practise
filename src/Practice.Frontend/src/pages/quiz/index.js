import React, {Component} from 'react';
import {connect} from "react-redux";
import LecturesService from "../../services/lecturesService";
import _isEmpty from "lodash/isEmpty";
import {Preloader} from '../../components/preloader';
import AuthService from "../../services/authService";

class Quiz extends Component {
    constructor(props) {
        super(props);

        this.state = {
            questions: []
        };
    }

    componentDidMount() {
        window.scrollTo(0, 0);
    }

    onChangeAnswer = (answerId, questionId) => {
        const result = this.state.questions.some(question => question.questionId === questionId);
        if (result) {
            this.setState({
                questions: this.state.questions.map((question) =>
                    question.questionId === questionId
                        ? {answerId, questionId}
                        : question)
            })
        } else {
            this.setState({
                questions: [
                    ...this.state.questions, {
                        answerId,
                        questionId
                    }
                ]
            })
        }
    };

    onQuiz = () => {
        const lectureId = this.props.lecture.id;
        const session = JSON.parse(localStorage.getItem('education_recourse_session')).session;
        const {questions} = this.state;

        const data = {
            lectureId,
            questions
        };

        Preloader.show();

        LecturesService.sendAnswer(session, data)
            .then((data) => this.props.onAnswerChange(data))
            .then(() => AuthService.getProfile(session)
                .then((data) => {
                    this.props.onProfileInfoChange(data);
                }))
            .then(() => this.props.history.push(`${this.props.match.url}/answer`))
            .then(() => {
                this.props.onCurrentElementChange('answer');
                Preloader.hide();
            });
    };

    render() {
        const {lecture} = this.props;
        return !_isEmpty(lecture)
            ? <div className="column is-fullwidth has-text-centered">
                <h2 className="title is-4">{lecture.title}</h2>
                {lecture.questions.map((question) => (
                    <div key={question.id} className="column box">
                        <h2 className="subtitle is-5 has-text-weight-semibold is-pulled-left">{question.text}</h2>
                        <div className="control box">
                            <form>
                                {question.answers.map(answer =>
                                    <label style={{marginLeft: 0}} className="radio column is-12">
                                        <input
                                            onChange={() => this.onChangeAnswer(answer.id, question.id)}
                                            id={answer.id}
                                            type="radio"
                                            name={question.id}/>
                                        {answer.text}
                                    </label>
                                )}
                            </form>
                        </div>
                    </div>
                ))}
                <button onClick={this.onQuiz} className="button is-link">Закончить тест</button>
            </div>
            : <div/>
    }
}

const mapStateToProps = state => ({
    lecture: state.lecture
});

const dispatchStateToProps = dispatch => ({
    onAnswerChange: (answer) => {
        dispatch({type: 'SET_ANSWER', item: answer})
    },
    onProfileInfoChange: (profile) => {
        dispatch({type: 'GET_PROFILE', item: profile})
    }
});

export default connect(mapStateToProps, dispatchStateToProps)(Quiz);
