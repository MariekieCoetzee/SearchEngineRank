import React, { useState } from "react";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import SearchResults from "./SearchResults";

const SearchQuery = (data) => {
    const [query, setQuery] = useState(data.data);
    const [results, setResults] = useState([]);

    function handleSearchQuery(e) {
        e.preventDefault();
        const { name, value } = e.target;
        setQuery({ ...query, [name]: value });
    }

    function prepareSearchQuery(e) {
        e.preventDefault();
        const formData = new FormData();
        formData.append("Keywords", query.keywords);
        formData.append("SearchUrl", query.searchUrl);
        formData.append("SearchEngine", query.searchEngine);
        submitSearchQuery(formData);
    }

    function submitSearchQuery(formData) {
        fetch("/search", {
            method: "POST",
            body: formData,
        })
            .then((response) => response.json())
            .then((data) => setResults(data))
            .catch((error) => console.error("unable to get results. ", error));
    }

    const { searchUrl, keywords, searchEngine } = query;

    return (
        <div className="background-color-lighter">
            <div className="mt-5" >
                <div className="ml-5" style={{ position: "absolute" }}>
                    <div style={{ borderLeft: "1px", height: "200px", borderStyle: "solid" }}> </div>
                </div>
                <form className="container" onSubmit={prepareSearchQuery}>

                    <div className="form-group row">
                        <FontAwesomeIcon icon={['fas', 'fa-address-book']} size="3x" />
                        <label className="col-sm-1 col-form-label">
                            Keywords
                        </label>
                        <div className="col-sm-11">
                            <input
                                type="text"
                                name="keywords"
                                onChange={handleSearchQuery}
                                className="form-control"
                                placeholder="online title search"
                                aria-label="Keywords"
                                value={keywords}
                            ></input>
                        </div>
                    </div>
                    <div className="form-group row">
                        <label className="col-sm-1 col-form-label">Domain</label>
                        <div className="col-sm-11">
                            <input
                                type="text"
                                name="searchUrl"
                                onChange={handleSearchQuery}
                                className="form-control"
                                value={searchUrl}
                            ></input>
                        </div>
                    </div>
                    <div className="form-group row">
                        <label className="col-sm-1 col-form-label">Engine</label>
                        <div className="col-sm-11">
                            <select
                                id="selectEngine"
                                name="searchEngine"
                                onChange={handleSearchQuery}
                                value={searchEngine}
                                className="form-control"
                            >
                                <option value="Google">Google</option>
                                <option value="Bing">Bing</option>
                            </select>
                        </div>
                    </div>
                    <button type="submit" style={{ width: "inherit" }} className="btn-SERank pushable">
                        <span className="shadow"></span>
                        <span className="edge"></span>
                        <span className="front">
                            Search
  </span>
                    </button>
                </form>
            </div>
            <SearchResults data={results} />
        </div >
    );
};
export default SearchQuery;
