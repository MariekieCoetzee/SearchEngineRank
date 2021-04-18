import "bootstrap/dist/css/bootstrap.css";
import React from "react";
import Icon from "./components/Icon";
import ReactDOM from "react-dom";
import { BrowserRouter } from "react-router-dom";
import App from "./App";

import registerServiceWorker from "./registerServiceWorker";

const baseUrl = document.getElementsByTagName("base")[0].getAttribute("href");
const rootElement = document.getElementById("root");



ReactDOM.render(
    <BrowserRouter basename={baseUrl}>
        <div className="background-color-lighter" style={{ height: "100vh" }}>
            <Icon />
            <div className="row">
                <div className="col-sm-12 mt-2">
                    <img className="m-2" width="130px" src={require('./images/serank.png')} style={{ position: "absolute" }} />
                    <h2 style={{ textDecoration: "underline", textUnderlineOffset: "35%", textAlign: "-webkit-center" }}>Search Engine Ranking</h2>
                </div>
            </div>
            <div className="row">
                <div className="col-sm-12 mt-4" style={{ textAlign: "-webkit-center" }}>
                    <div className="text-center background-color-dark p-1 text-white mb-2 p-3" style={{ borderStyle: "solid", borderWidth: "0.1em", borderRadius: "10px", width: "fit-content" }}>
                        Specify keywords and URL hit <strong>Search</strong> to view performance.
                    </div>
                </div>
            </div>

            <App />
        </div>
    </BrowserRouter>,
    rootElement
);

registerServiceWorker();
