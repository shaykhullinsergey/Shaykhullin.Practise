import React, {Component} from 'react';
import * as d3 from 'd3';

class PieChart extends Component {
    componentDidMount() {
        const rad = 12;
        const width = this.props.size[0] / rad,
            height = this.props.size[1] / rad,
            radius = Math.min(width, height) / 2;
        const color = d3.scaleOrdinal(d3.schemeCategory10);
        const plusResult = this.props.result.results;
        const minusResult = 5 - plusResult;

        const pie = d3.pie()
            .value(function (d) {
                return d;
            })
            .sort(null);

        const arc = d3.arc()
            .innerRadius(radius - this.props.innerRadius / rad)
            .outerRadius(radius - 20 / rad);

        const svg = d3.select(this.pieChart)
            .attr("width", width)
            .attr("height", height)
            .append("g")
            .attr("transform", "translate(" + width / 2 + "," + height / 2 + ")");

        svg
            .datum([plusResult, minusResult])
            .selectAll("path")
            .data(pie)
            .enter().append("path")
            .attr("fill", function (d, i) {
                return color(i);
            })
            .attr("d", arc);
    }

    render() {
        return (
            <svg xmlns="http://www.w3.org/2000/svg" ref={node => (this.pieChart = node)}/>
        );
    }
}

export default PieChart;
