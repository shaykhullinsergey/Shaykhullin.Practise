import React, {Component} from "react";
import {connect} from "react-redux";
import _isEmpty from 'lodash/isEmpty';
import Remarkable from 'remarkable';

const markdown = new Remarkable('full', {
    html: true,
    linkify: true,
    typographer: true,
});

class Lecture extends Component {
    onQuiz = () => this.props.onCurrentElementChange('quiz');
    
    render() {
        const {lecture} = this.props;

        return !_isEmpty(lecture)
            ? <div className="column">
                <h2 className="title is-4">{lecture.title}</h2>
                {lecture.chapters.map((chapter) => (
                    <div key={chapter.title} className="column">
                        <h2 className="subtitle is-5">{chapter.title}</h2>
                        <p dangerouslySetInnerHTML={{__html: markdown.render('# Я h1 и хочу выделяться')}}></p>
                    </div>
                ))}
                <div className="columns is-centered">
                    <div className="column is-2">
                        <button onClick={this.onQuiz} className="button is-link">Пройти тест</button>
                    </div>
                </div>
            </div>
            : null;
    }
}

const mapStateToProps = state => ({
    lecture: state.lecture
});

export default connect(mapStateToProps)(Lecture);
