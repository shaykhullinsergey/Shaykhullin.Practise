import React, {Component} from "react";
import {connect} from "react-redux";
import _isEmpty from 'lodash/isEmpty';
import Lecture from "../lecture";
import Quiz from "../quiz";
import NotChoosenLecture from "../notChoosenLecture";
import AuthService from "../../services/authService";
import PieChart from "../../components/pieChart";
import LecturesService from "../../services/lecturesService";
import Answer from "../answer";

class Lectures extends Component {
    constructor(props) {
        super(props);

        this.state = {}
    }

    componentDidMount() {
        const {sessionId} = this.props.match.params;
        AuthService.getProfile(sessionId)
            .then((data) =>
                this.setState({...data, currentElement: 'not-chosen'})
            );
    }

    onLectureChange = (lectureId) => {
        LecturesService.getLecture(lectureId)
            .then((data) => {
                    this.props.onLectureChange({...data, id: lectureId});
                    this.setState({currentElement: 'lecture'})
                }
            )
            .then(() => this.props.history.push(`${this.props.match.url}/lecture/${lectureId}`));
    };

    onCurrentElementChange = (element) => {
        this.setState({
            currentElement: element
        })
    };

    onExit = () => {
        localStorage.clear();
        this.props.history.replace("/auth", null);
    };

    render() {
        const {name, group, lectures, currentElement} = this.state;
        return <div style={{position: 'absolute'}} className="columns">
            <aside style={{
                borderRight: '1px solid #303f9f',
                backgroundColor: 'rgb(244, 245, 247)',
                minWidth: '200px',
                maxWidth: '200px'
            }}
                   className="menu column is-fullheight">
                <div className="column">
                    <h2 className="title is-5">{!_isEmpty(name) && name}</h2>
                    <h2 className="subtitle is-6">{!_isEmpty(group) && group}</h2>
                    <button onClick={this.onExit} className="button is-small">Выйти</button>
                </div>
                <p className="menu-label column is-centered">
                    Лекции
                </p>
                <ul className="menu-list">
                    {!_isEmpty(lectures) && lectures.map((lecture) =>
                        (
                            <li key={lecture.id}>
                                <a
                                    onClick={() => this.onLectureChange(lecture.id)}
                                    style={{paddingLeft: '30px'}}
                                    className="columns">
                                    <PieChart size={[500,500]} innerRadius={100} result={{
                                        results: lecture.result
                                    }}/>
                                    <p className="column">{lecture.title}</p>
                                </a>
                            </li>
                        ))
                    }
                </ul>
            </aside>
            {currentElement === 'not-chosen' && <NotChoosenLecture/>}
            {currentElement === 'lecture' &&
            <Lecture {...this.props}
                     onCurrentElementChange={this.onCurrentElementChange}/>}
            {currentElement === 'quiz' && <Quiz {...this.props} onCurrentElementChange={this.onCurrentElementChange}/>}
            {currentElement === 'answer' && <Answer {...this.props} onCurrentElementChange={this.onCurrentElementChange}/>}
        </div>
    }
}

const dispatchStateToProps = dispatch => ({
    onLectureChange: (lecture) => {
        dispatch({type: 'SET_LECTURE', item: lecture})
    }
});

export default connect(null, dispatchStateToProps)(Lectures);
