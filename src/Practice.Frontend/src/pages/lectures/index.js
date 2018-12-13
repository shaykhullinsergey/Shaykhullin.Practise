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
import {Preloader} from "../../components/preloader";

class Lectures extends Component {
    constructor(props) {
        super(props);

        this.state = {};
        this.cross = 'm22,0c-12.2,0-22,9.8-22,22s9.8,22 22,22 22-9.8 22-22-9.8-22-22-22zm3.2,22.4l7.5,7.5c0.2,0.2 0.3,0.5 0.3,0.7s-0.1,0.5-0.3,0.7l-1.4,1.4c-0.2,0.2-0.5,0.3-0.7,0.3-0.3,0-0.5-0.1-0.7-0.3l-7.5-7.5c-0.2-0.2-0.5-0.2-0.7,0l-7.5,7.5c-0.2,0.2-0.5,0.3-0.7,0.3-0.3,0-0.5-0.1-0.7-0.3l-1.4-1.4c-0.2-0.2-0.3-0.5-0.3-0.7s0.1-0.5 0.3-0.7l7.5-7.5c0.2-0.2 0.2-0.5 0-0.7l-7.5-7.5c-0.2-0.2-0.3-0.5-0.3-0.7s0.1-0.5 0.3-0.7l1.4-1.4c0.2-0.2 0.5-0.3 0.7-0.3s0.5,0.1 0.7,0.3l7.5,7.5c0.2,0.2 0.5,0.2 0.7,0l7.5-7.5c0.2-0.2 0.5-0.3 0.7-0.3 0.3,0 0.5,0.1 0.7,0.3l1.4,1.4c0.2,0.2 0.3,0.5 0.3,0.7s-0.1,0.5-0.3,0.7l-7.5,7.5c-0.2,0.1-0.2,0.5 3.55271e-15,0.7z';
        this.question = 'M255,0C114.75,0,0,114.75,0,255s114.75,255,255,255s255-114.75,255-255S395.25,0,255,0z M280.5,433.5h-51v-51h51V433.5zM334.05,237.15L311.1,260.1c-20.399,17.851-30.6,33.15-30.6,71.4h-51v-12.75c0-28.05,10.2-53.55,30.6-71.4L290.7,214.2c10.2-7.65,15.3-20.4,15.3-35.7c0-28.05-22.95-51-51-51s-51,22.95-51,51h-51c0-56.1,45.9-102,102-102c56.1,0,102,45.9,102,102C357,201.45,346.8,221.85,334.05,237.15z';
        this.check = 'M213.333,0C95.518,0,0,95.514,0,213.333s95.518,213.333,213.333,213.333c117.828,0,213.333-95.514,213.333-213.333S331.157,0,213.333,0z M174.199,322.918l-93.935-93.931l31.309-31.309l62.626,62.622l140.894-140.898l31.309,31.309L174.199,322.918z';
    }

    componentDidMount() {
        const {sessionId} = this.props.match.params;
        AuthService.getProfile(sessionId)
            .then((data) =>
                this.props.onProfileInfoChange({...data, currentElement: 'not-chosen'})
            );
    }

    onLectureChange = (lectureId) => {
        Preloader.show();

        LecturesService.getLecture(lectureId)
            .then((data) => {
                    this.props.onLectureChange({...data, id: lectureId});
                    this.props.onProfileInfoChange({currentElement: 'lecture'})
                }
            ).then(() => Preloader.hide());
    };

    onCurrentElementChange = (element) => {
        this.props.onProfileInfoChange({
            currentElement: element
        })
    };

    onExit = () => {
        localStorage.clear();
        this.props.history.replace("/auth", null);
    };

    render() {
        const {name, group, lectures, currentElement} = this.props.profile;
        console.log(lectures)
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
                                    <PieChart
                                        size={[500, 500]}
                                        innerRadius={100}
                                        result={{results: lecture.result}}
                                        style={lecture.result === null
                                            ? {
                                                icon: this.question,
                                                mainColor: '#FDD835',
                                                secondColor: '#FFF176',
                                                type: 'question'
                                            }
                                            : lecture.result === 5
                                                ? {
                                                    icon: this.check,
                                                    mainColor: '#388E3C',
                                                    secondColor: '#66BB6A',
                                                    type: 'check'
                                                }
                                                : {
                                                    icon: this.cross,
                                                    mainColor: '#d32f2f',
                                                    secondColor: '#f44336',
                                                    type: 'cross'
                                                }}
                                    />
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
            {currentElement === 'answer' &&
            <Answer {...this.props} onCurrentElementChange={this.onCurrentElementChange}/>}
        </div>
    }
}

const mapStateToProps = (state) => ({
    profile: state.profile
});

const dispatchStateToProps = dispatch => ({
    onLectureChange: (lecture) => {
        dispatch({type: 'SET_LECTURE', item: lecture})
    },
    onProfileInfoChange: (profile) => {
        dispatch({type: 'GET_PROFILE', item: profile})
    }
});

export default connect(mapStateToProps, dispatchStateToProps)(Lectures);
