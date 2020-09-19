import PropTypes from "prop-types";
import React, { Component } from 'react';


export class SearchResult extends Component {
    static propTypes = {
        details: PropTypes.shape({
            searchEngine: PropTypes.string,
            title: PropTypes.string,
            searchPhrase: PropTypes.string,
            enteredDate: PropTypes.string
        })
    };

    render() {
        const { searchEngine, title, searchPhrase, enteredDate } = this.props;
        return (
            <li>

                <p> {searchEngine}</p>
                <p> {searchPhrase}</p>
                <p> {title}</p>
                <p> {enteredDate}</p>
            </li>
        );
    }
}
