import React, { Component } from "react";
import { SearchQuery } from "./SearchQuery";

const SearchResults = ({ data }) => {
  if (data.length === 0) return null;
  console.log(data);
  return (
    <div class="container">
      <table class="table table-striped">
        <thead>
          <tr>
            <th scope="col">Rank</th>
            <th scope="col">Name</th>
            <th scope="col">Domain</th>
            <th scope="col">URL</th>
          </tr>
        </thead>
        <tbody>
          {data.map((item, index) => {
            return (
              <tr key={index}>
                <td scope="row">{item.position}</td>
                <td>{item.name}</td>
                <td>{item.domainName}</td>
                <td>
                  <a href={item.url}>{item.url}</a>
                </td>
              </tr>
            );
          })}
        </tbody>
      </table>
    </div>
  );
};
export default SearchResults;
