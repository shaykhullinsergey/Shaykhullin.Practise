import React, {Component} from 'react';
import * as d3 from 'd3';

class PieChart extends Component {
    componentDidMount() {
        console.log(this.props)
        const rad = 12;
        const {icon, mainColor, secondColor, type} = this.props.style;
        const width = this.props.size[0] / rad,
            height = this.props.size[1] / rad,
            radius = Math.min(width, height) / 2;
        const color = [mainColor, mainColor, mainColor];
        const scale = type === 'check'
            ? 0.061
            : type === 'cross'
                ? 0.6
                : 0.05

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
            .datum([1])
            .selectAll("path")
            .data(pie)
            .enter().append("path")
            .attr("fill", function (d, i) {
                return color[i];
            })
            .attr("d", arc);

        svg.append("path")
            .attr('d', icon)
            .attr('fill', secondColor)
            .attr('transform', `translate(-13, -13) scale(${scale})`)
    }

    render() {
        return (
            <svg xmlns="http://www.w3.org/2000/svg" ref={node => (this.pieChart = node)}/>
        );
    }
}

export default PieChart;
