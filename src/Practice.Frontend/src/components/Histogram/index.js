import React, {Component} from 'react';
import PropTypes from 'prop-types';
import classNames from 'classnames';
import _capitalize from 'lodash/capitalize';
import * as d3 from 'd3';
import './Histogram.css';

const colorMap = index => ({
    0: '#84bdff',
    1: '#2b7cda',
    2: '#1d5ca4',
    3: '#f55246',
    4: '#ba160a',
    5: '#ba68c8',
    6: '#a536a8',
    7: '#810f7c'
}[index]);

export default class NeoantigensTypesChart extends Component {
    static propTypes = {
        chartData: PropTypes.arrayOf(
            PropTypes.shape({
                label: PropTypes.string.isRequired,
                value: PropTypes.number.isRequired
            })
        ).isRequired,
        setTypeColorClass: PropTypes.func.isRequired
    };

    constructor(props) {
        super(props);
        this.margin = {top: 20, bottom: 0, left: 0, right: 0};
        this.width = 540;
        this.height = 44;
        this.radius = 3;
        this.state = {
            hoveredLabel: ''
        };

        this.update = this.update.bind(this);
    }

    componentDidMount() {
        this.update();
    }

    update() {
        const {width, height, margin, radius} = this;
        const {chartData, setTypeColorClass} = this.props;
        const total = d3.sum(chartData, d => d.value);
        let index = 0;
        const barData = chartData
            .map(bar => ({...bar, calcValue: (bar.value / total) * 100}))
            .map((bar, barIndex, barArray) =>
                barArray.reduce(
                    (result, elem, index) => ({
                        ...result,
                        barIndex,
                        [index]: index > barIndex ? 0 : index === barIndex ? bar.value : barArray[index].calcValue
                    }),
                    {...bar}
                )
            );
        const dataset = d3.stack().keys(chartData.map((clone, index) => index))(barData);
        const sortedDataset = dataset.map((bar, index) => [bar[index]]);
        const x = d3
            .scaleLinear()
            .rangeRound([0, width])
            .domain([0, 100]);
        const svg = d3
            .select(this.stackedChart)
            .attr('width', width + margin.left + margin.top)
            .attr('height', height + margin.top + margin.bottom)
            .append('g');
        const bar = svg
            .selectAll('g')
            .data(sortedDataset)
            .enter();
        bar
            .selectAll('text')
            .data(d => d)
            .enter()
            .filter(d => x(d[1]) - x(d[0]) > 50)
            .append('text')
            .attr('class', 'neoantigens-types-chart__chart-text')
            .attr('transform', d => `translate(${x(d[0])},${margin.top - 10})`)
            .text(d => `${d.data.value.toFixed(1)}%`);
        bar
            .append('g')
            .attr('transform', `translate(${margin.left},${margin.top})`)
            .selectAll('path')
            .data(d => d)
            .enter()
            .append('path')
            .attr('d', d => {
                if (sortedDataset.length === 1)
                    return `M${x(d[0])},${height - radius}v${2 * radius -
                    height}a${radius},${radius} 0 0 1 ${radius},${-radius}h${width -
                    2 * radius}a${radius},${radius} 0 0 1 ${radius},${radius}v${height -
                    2 * radius}a${radius},${radius} 0 0 1 ${-radius},${radius}h${-(
                        width -
                        2 * radius
                    )}a${radius},${radius} 0 0 1 ${-radius},${-radius}z`;
                if (d.data.barIndex === 0)
                    return `M${x(d[0])},${height - radius}v${2 * radius -
                    height}a${radius},${radius} 0 0 1 ${radius},${-radius}h${x(d[1]) - x(d[0]) - radius}v${height}h${-(
                        x(d[1]) -
                        x(d[0]) -
                        radius
                    )}a${radius},${radius} 0 0 1 ${-radius},${-radius}z`;
                if (d.data.barIndex === sortedDataset.length - 1) {
                    return `M${x(d[0])},${height}v${-height}h${x(d[1]) -
                    x(d[0]) -
                    radius}a${radius},${radius} 0 0 1 ${radius},${radius}v${height -
                    2 * radius}a${radius},${radius} 0 0 1 ${-radius},${radius}h${-(x(d[1]) - x(d[0]) - radius)}z`;
                }
                return `M${x(d[0])},${height}v${-height}h${x(d[1]) - x(d[0])}v${height}h${-(x(d[1]) - x(d[0]))}z`;
            })
            .attr('fill', (d) => colorMap(d.data.index))
            .style('opacity', 0.75)
            .on('mouseover', d => {
                bar
                    .selectAll('path')
                    .filter(elem => elem.data.barIndex === d.data.barIndex)
                    .style('opacity', 1);
                this.setState({hoveredLabel: d.data.label});
            })
            .on('mouseout', () => {
                bar.selectAll('path').style('opacity', 0.75);
                this.setState({hoveredLabel: ''});
            });
    }

    render() {
        const {chartData} = this.props;
        const {hoveredLabel} = this.state;
        return (
            <div className="neoantigens-types-chart__chart-wrapper">
                <svg xmlns="http://www.w3.org/2000/svg" ref={node => (this.stackedChart = node)}/>
                <div className="neoantigens-types-chart__legend-list">
                    {chartData.map((neoantigen, index) => {
                        const textClasses = classNames({
                            'neoantigens-types-chart__legend-item-text': true,
                            'neoantigens-types-chart__legend-item-text--selected': neoantigen.label === hoveredLabel
                        });
                        return (
                            <div key={neoantigen.label} className="neoantigens-types-chart__legend-item">
                                <div
                                    className="neoantigens-types-chart__legend-item-indicator"
                                    style={{background: colorMap(neoantigen.index)}}
                                />
                                <div className={textClasses}>
                                    <div
                                        className="neoantigens-types-chart__legend-item-label">{_capitalize(neoantigen.label)}</div>
                                    <div
                                        className="neoantigens-types-chart__legend-item-percent">{neoantigen.value.toFixed(1)}%
                                    </div>
                                </div>
                            </div>
                        );
                    })}
                </div>
            </div>
        );
    }
}
