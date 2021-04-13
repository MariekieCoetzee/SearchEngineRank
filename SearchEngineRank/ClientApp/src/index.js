import "bootstrap/dist/css/bootstrap.css";
import React from "react";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { library } from '@fortawesome/fontawesome-svg-core';
import { fas } from '@fortawesome/free-solid-svg-icons'
import { fab } from '@fortawesome/free-brands-svg-icons';
import ReactDOM from "react-dom";
import { BrowserRouter } from "react-router-dom";
import App from "./App";

import registerServiceWorker from "./registerServiceWorker";

const baseUrl = document.getElementsByTagName("base")[0].getAttribute("href");
const rootElement = document.getElementById("root");

library.add(fab, fas);

ReactDOM.render(
    <BrowserRouter basename={baseUrl}>
        <header>
            <nav className="navbar navbar-expand-sm navbar-toggleable-sm navbar-light bg-white border-bottom box-shadow mb-3">
                <div className="container" style={{ justifyContent: "left" }}>
                    <FontAwesomeIcon icon={['fab', 'searchengin']} size="3x" />
                    <h2 style={{ paddingLeft: "10%" }}>
                        
                        <strong>S</strong>earch <strong>E</strong>ngine <strong>R</strong>
            ank
          </h2>
                </div>
            </nav>
        </header>
        <App />
    </BrowserRouter>,
    rootElement
);

registerServiceWorker();
