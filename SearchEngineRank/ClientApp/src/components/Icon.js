import React from "react";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { library } from '@fortawesome/fontawesome-svg-core';
import { fas } from '@fortawesome/free-solid-svg-icons'
import { fab } from '@fortawesome/free-brands-svg-icons';

library.add(fab, fas);

const Icon = () => {
    return (
        <div style={{ position: "absolute", left: "0", right: "0", top: "25%" }}>
            <div className="row mb-4 mb-1 mr-1" >
                <div className="col-sm-12 text-right" >
                    <FontAwesomeIcon icon="arrow-down" size="3x" className="color-light" />
                </div>
            </div>
            <div className="row mb-4 mb-1 mr-1">
                <div className="col-sm-12 text-right" >
                    <FontAwesomeIcon icon="arrow-down" size="3x" className="color-light" />
                </div>
            </div>
            <div className="row mb-4 mb-1 mr-1">
                <div className="col-sm-12 text-right" >
                    <FontAwesomeIcon icon="arrow-down" size="3x" className="color-light" />
                </div>
            </div>
            <div className="row mb-4 mb-1 mr-1">
                <div className="col-sm-12 text-right">
                    <FontAwesomeIcon icon="arrow-up" size="3x" className="color-contrast" />
                </div>
            </div>
            <div className="row mb-4 mb-1 mr-1">
                <div className="col-sm-12 text-right">
                    <FontAwesomeIcon icon="arrow-up" size="3x" className="color-contrast" />
                </div>
            </div>
            <div className="row mb-4 mb-1 mr-1">
                <div className="col-sm-12 text-right">
                    <FontAwesomeIcon icon="arrow-up" size="3x" className="color-contrast" />
                </div>
            </div>
        </div>
    )
}

export default Icon;