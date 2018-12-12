import React from "react";
import {Component} from "react";
import {connect} from "react-redux";
import _toLower from 'lodash/toLower';
import AnswerPieChart from "../../components/answerPieChart";
import NeoantigensTypesChart from "../../components/Histogram";

class Answer extends Component {
    render() {
        return <div className="column is-fullwidth">
            <div className="columns is-12">
                <div className="column is-4" style={{marginTop: '30px', marginLeft: '170px'}}>
                    <AnswerPieChart size={[5000, 5000]} innerRadius={250}
                                    result={{results: this.props.answer.results.filter(value => value === true).length}}/>
                </div>
                <div className="column is-4" style={{marginTop: '100px'}}>
                    {this.props.answer.results.map((result, index) =>
                        result
                            ? <h1 className="title">{index + 1}: Правильно</h1>
                            : <h1 className="title">{index + 1}: Неправильно</h1>
                    )}
                </div>
            </div>

            <div className="biomarkers-details-page__section">
                <NeoantigensTypesChart chartData={
                    Object.keys(this.props.answer.statistics).map((e, index) => {
                        const fullValue = 100 / Object.keys(this.props.answer.statistics)
                            .reduce((number, g) => number + this.props.answer.statistics[g], 0);
                        console.log(fullValue)
                        return ({
                            index,
                            label: `${e} правильных ответов`,
                            value: this.props.answer.statistics[e] * fullValue
                        })
                    })
                }
                                       some={(type) => {
                                           const colors = {
                                               frameshift: '#2b7cda',
                                               'snv at hla anchors, strong binder': '#962294',
                                               'snv at other sites, strong binder': '#c8b58b',
                                               'other epitopes': '#f4ae63'
                                           };
                                           return colors[_toLower(type)];
                                       }}
                />
            </div>
        </div>
    }
}

const mapStateToProps = state => ({
    answer: state.answer
});

export default connect(mapStateToProps)(Answer);
