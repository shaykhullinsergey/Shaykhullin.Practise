import React, {Component} from "react";
import {connect} from "react-redux";
import _isEmpty from 'lodash/isEmpty';
import ReactMarkdown from "react-markdown";

class Lecture extends Component {
    constructor(props) {
        super(props);
        this.state = {};
    }

    onQuiz = () => {
        this.props.onCurrentElementChange('quiz');
    };

    render() {
        const {lecture} = this.props;
        return !_isEmpty(lecture)
            ? <div className="column">
                <h2 className="title is-4">{lecture.title}</h2>
                {lecture.chapters.map((chapter) => (
                    <div key={chapter.title} className="column">
                        <h2 className="subtitle is-5">{chapter.title}</h2>
                        <ReactMarkdown source={chapter.text}/>
                    </div>
                ))}
                <div className="columns is-centered">
                    <div className="column is-2">
                        <button onClick={this.onQuiz} className="button is-link">Пройти тест</button>
                    </div>
                </div>
            </div>
            : <div/>
    }
}

const mapStateToProps = state => ({
    lecture: state.lecture
});

export default connect(mapStateToProps)(Lecture);
