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

    componentDidMount() {
        window.scrollTo(0, 0);
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
                    <button onClick={this.onQuiz} className="button is-link">Пройти тест</button>
                </div>
            </div>
            : null;
    }
}

const mapStateToProps = state => ({
    lecture: state.lecture
});

export default connect(mapStateToProps)(Lecture);
