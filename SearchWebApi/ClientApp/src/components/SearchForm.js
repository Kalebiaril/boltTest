import React, { Component } from 'react';
import { SearchResult } from './SearchResult';

export class SearchForm extends Component {
    static displayName = SearchForm.name;

    state = {
        searchString: '',
        isLoaded: false,
        items: []
    };

    handleSubmit = async (event) => {
        event.preventDefault();
        var data = { SearchPhrase: this.state.searchString };
        fetch("/api/search", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(data)
        })
            .then(res => res.json())
            .then(
                (result) => {
                    this.setState({
                        isLoaded: true,
                        items: result
                    });
                },

                (error) => {
                    this.setState({
                        isLoaded: false,
                        error
                    });
                }
            )
    };

    renderSearchResult() {
        return (
            <div>
                <h1> Search result </h1>
                <ul className="fishes">
                    {this.state.items.map((key) => (
                       
                        <SearchResult
                            searchEngine={key.searchEngine}
                            title={key.title}
                            searchPhrase={key.request}
                            enteredDate={key.enteredDate}
                        />
                    ))}
                </ul>
            </div>);
    };

     
    render() {
        return (
            <div>
                <h1>Search Form</h1>
                <form onSubmit={this.handleSubmit}>
                    <input
                        type="text"
                        value={this.state.searchString}
                        onChange={event => this.setState({ searchString: event.target.value })}
                        placeholder="Enter Search string"
                        required
                    />
                    <button>Go!</button>
                </form>

                {this.state.isLoaded && this.renderSearchResult()}
            </div>
        );
    }
}
