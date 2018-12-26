import React, {Component} from "react";
import {connect} from "react-redux";
import _isEmpty from 'lodash/isEmpty';
import Remarkable from 'remarkable';
import LecturesService from "../../services/lecturesService";
import AuthService from "../../services/authService";

const markdown = new Remarkable('full', {
    html: true,
    linkify: true,
    typographer: true,
});

class Lecture extends Component {
    onQuiz = () => this.props.onCurrentElementChange('quiz');
    onPractice = () => {
        this.props.onCurrentElementChange('practice');

        const {id} = this.props.lecture;

        const session = JSON.parse(localStorage.getItem('education_recourse_session')).session;
        LecturesService.explicitlyCompletePractice(session, id)
            .then(() => AuthService.getProfile(session)
            .then((data) => {
                console.log(data);
                this.props.onLectureChange({...data, id});
                this.props.onProfileInfoChange(data);
            }));
    }

    componentDidMount() {
        window.scrollTo(0, 0);
    }

    renderButton() {
        return this.props.lecture.isPractice
            ? <button onClick={this.onPractice} className="button is-link">Завершить практику</button>
            : <button onClick={this.onQuiz} className="button is-link">Пройти тест</button>;
    }

    render() {
        const {lecture} = this.props;

        return !_isEmpty(lecture)
            ? <div className="column box has-text-centered">
                <div className="box">
                    <h2 className="title is-4">{lecture.title}</h2>

                    {lecture.chapters.map((chapter) => (
                        <div key={chapter.title} className="column box">
                            <h2 className="subtitle is-5">{chapter.title}</h2>
                            <p style={{textAlign: 'left'}} dangerouslySetInnerHTML={{__html: markdown.render(chapter.text)}}></p>
                        </div>
                    ))}
                    {this.renderButton()}
                </div>
            </div>
            : null;
    }
}

const mapStateToProps = state => ({
    lecture: state.lecture
});

export default connect(mapStateToProps)(Lecture);
