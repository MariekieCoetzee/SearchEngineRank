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
    <div>
      <div className="jumbotron jumbotron-fluid bg-info rounded">
        <form className="container" onSubmit={prepareSearchQuery}>
          <div className="text-left">
            <div className="text-white">
              Specify keywords and URL hit <strong>Search</strong> to view
              performance
            </div>
            <hr />
          </div>
          <div className="form-group row">
                      <FontAwesomeIcon icon={['fas', 'fa-address-book']} size="3x" />
            <label className="col-sm-1 col-form-label text-white">
              Keywords{" "}
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
            <label className="col-sm-1 col-form-label text-white">Domain</label>
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
            <label className="col-sm-1 col-form-label text-white">Engine</label>
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
          <button
            type="submit"
            style={{ width: "inherit" }}
                      className="btn btn-SERank"
          >
            Search
          </button>
        </form>
      </div>
      <SearchResults data={results} />
    </div>
  );
};
export default SearchQuery;
