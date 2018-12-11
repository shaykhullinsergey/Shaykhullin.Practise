import React from "react";
import {Component} from "react";
import {connect} from "react-redux";
import PieChart from "../../components/pieChart";
import Histogram from "../../components/Histogram";

class Answer extends Component {
    render() {
        return <div className="column is-fullwidth">
            <PieChart size={[5000, 5000]} innerRadius={250}
                      result={{results: this.props.answer.results.filter(value => value === true).length}}/>
            <div className="biomarkers-details-page__section">
                <Histogram chart={{
                    values: this.props.answer.statistics
                }}
                           closestPatientNode={1}
                           patientNodeColor={1}
                           currentPatientValue={1}
                           chartTitle={'Students results'}
                />
            </div>
        </div>
    }
}

const mapStateToProps = state => ({
    answer: state.answer
});

export default connect(mapStateToProps)(Answer);
