import React, {Component} from 'react';
import PropTypes from 'prop-types';
import * as d3 from 'd3';
// import './Histogram.css';

export default class Histogram extends Component {
    static rightRoundedRect(x, y, width, height, radius) {
        return `M${x},${y + height}v${radius
        - height}a${radius},${radius} 0 0 1 ${radius},${-radius}h${width
        - 2 * radius}a${radius},${radius} 0 0 1 ${radius},${radius}v${height - radius}h${width}z`;
    }

    constructor(props) {
        super(props);
        this.margin = {
            top: 20,
            right: 50,
            bottom: 50,
            left: 50
        };
        this.xAxisHeight = 2;
        this.mainColor = '#9fc4ee';
        this.update = this.update.bind(this);
    }

    componentDidMount() {
        const {margin} = this;
        this.width = 800
        this.height = (this.width * 4) / 7 - this.margin.top - this.margin.bottom;
        d3.select(this.histogram).style('width', `${this.width + margin.left}px`);
        this.update();
    }

    componentDidUpdate(prevProps) {
        if (prevProps !== this.props) {
            this.update();
        }
    }

    update() {
        const {
            margin, width, height, xAxisHeight, mainColor
        } = this;
        const {
            chart, patientNodeColor, closestPatientNode, currentPatientValue
        } = this.props;

        const updatedChart = {
            values:
                Object.keys(chart.values).map(e => ({
                        value: e,
                        count: chart.values[e]
                    })
                )
        };

        // gridlines in x axis function
        function makeXGridlines() {
            return d3
                .axisBottom(x)
                .tickFormat((d, i) => (i % 4 === 0 ? d : null))
                .tickPadding(8);
        }

        // gridlines in y axis function
        function makeYGridlines() {
            return d3
                .axisLeft(y)
                .ticks(4)
                .tickPadding(10);
        }

        function identationToClosestLeftChains(a) {
            return a < x.bandwidth() * 5 ? 40 : 0;
        }

        function identationToClosestRightChains(a) {
            return width - a < x.bandwidth() * 5 ? 40 : 0;
        }

        function showTooltip(d) {
            tooltip
                .html(
                    `<span class="histogram__tooltip-amount">${currentPatientValue.toFixed(3)}</span>
          <span class="histogram__tooltip-row histogram__tooltip-title">Current patient</span>`
                )
                .style(
                    'left',
                    `${x(d.value)
                    + margin.left
                    + identationToClosestLeftChains(x(d.value))
                    + x.bandwidth() / 2
                    - identationToClosestRightChains(x(d.value))
                    + -tooltip.node().getBoundingClientRect().width / 2}px`
                );
        }

        // clear before redrawing
        d3.select(this.histogram)
            .selectAll('*')
            .remove();
        // create chart
        const svg = d3
            .select(this.histogram)
            .attr('width', width + margin.left + margin.right)
            .attr('height', height + margin.top + margin.bottom)
            .append('g')
            .attr('transform', `translate(${margin.left}, ${margin.top})`);
        const x = d3
            .scaleBand()
            .rangeRound([0, width])
            .paddingInner(0.2);
        const y = d3.scaleLinear().range([height, 0]);
        x.domain(updatedChart.values.map(d => d.value));
        y.domain([0, d3.max(updatedChart.values, d => d.count)]).nice();
        const tooltip = d3.select(this.histogramTooltip);

        // add the X gridlines
        svg
            .append('g')
            .attr('class', 'grid')
            .attr('transform', `translate(0,${height})`)
            .call(makeXGridlines().tickSize(5));

        // add the Y gridlines
        svg
            .append('g')
            .attr('class', 'grid')
            .call(makeYGridlines().tickSize(-width));

        svg
            .append('text')
            .attr('class', 'axis-title')
            .attr('x', width / 2)
            .attr('y', height)
            .attr('dy', '2.75em')
            .style('text-anchor', 'middle')
            .text(updatedChart.xaxisLabel);

        svg
            .append('text')
            .attr('class', 'axis-title')
            .attr('transform', 'rotate(-90)')
            .attr('y', -margin.left)
            .attr('x', -height / 2)
            .attr('dy', '1em')
            .style('text-anchor', 'middle')
            .text(updatedChart.yaxisLabel);

        const chainGroup = svg
            .append('g')
            .selectAll('g')
            .data(updatedChart.values)
            .enter()
            .append('g')
            .attr('class', 'histogram__chain-group');

        chainGroup
            .append('path')
            .attr('class', 'histogram__background-bar')
            .attr('d', d => Histogram.rightRoundedRect(x(d.value), y(d.count), x.bandwidth(), height - y(d.count), 3))
            .attr('fill', '#ffffff');

        // append the rectangles for the bar chart
        chainGroup
            .append('path')
            .attr('class', 'histogram__bar')
            .attr('d', d => Histogram.rightRoundedRect(x(d.value), y(d.count), x.bandwidth(), height - y(d.count), 3))
            .attr('fill', d => (d.value === closestPatientNode.value ? patientNodeColor : mainColor))
            .style('opacity', 0.75);

        chainGroup
            .filter(d => d.value === closestPatientNode.value)
            .append('line')
            .attr('stroke', '#1b2834')
            .attr('stroke-dasharray', 6)
            .attr('x1', d => x(d.value) + x.bandwidth() / 2)
            .attr('y1', -20)
            .attr('x2', d => x(d.value) + x.bandwidth() / 2)
            .attr('y2', d => y(d.count))
            .each((d) => {
                showTooltip(d);
            });

        // add the X Axis
        svg
            .append('rect')
            .attr('transform', `translate(0,${height})`)
            .attr('width', width)
            .attr('height', xAxisHeight)
            .attr('fill', '#9bbce6');
    }

    render() {
        const {chartTitle} = this.props;
        return (
            <div className="histogram">
                <div className="histogram__title-container" ref={node => (this.titleContainer = node)}>
                    <div className="histogram__title">{chartTitle}</div>
                </div>
                <svg xmlns="http://www.w3.org/2000/svg" ref={node => (this.histogram = node)}/>
                <div className="histogram__tooltip" ref={node => (this.histogramTooltip = node)}/>
            </div>
        );
    }
}

Histogram.propTypes = {
    chart: PropTypes.shape({
        values: PropTypes.array.isRequired,
        xaxisLabel: PropTypes.string.isRequired,
        yaxisLabel: PropTypes.string.isRequired
    }).isRequired,
    closestPatientNode: PropTypes.shape({
        count: PropTypes.number,
        value: PropTypes.number
    }).isRequired,
    patientNodeColor: PropTypes.string.isRequired,
    currentPatientValue: PropTypes.number.isRequired,
    chartTitle: PropTypes.string.isRequired
};