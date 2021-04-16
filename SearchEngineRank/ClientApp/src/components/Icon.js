import React from "react";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { library } from '@fortawesome/fontawesome-svg-core';
import { fas } from '@fortawesome/free-solid-svg-icons'
import { fab } from '@fortawesome/free-brands-svg-icons';

library.add(fab, fas);

const Icon = () => {
    return (
        <div className="background-color-dark pt-3 pb-2 pl-3 pr-3" style={{ marginTop: "1%", marginLeft: "3%", position: "absolute", borderStyle: "solid", borderColor: "black", borderRadius: "5px", width: "100px", height: "100px" }}>
            <div className="background-color-lighter p-2" style={{ fontWeight: "500", fontSize: "x-small", borderStyle: "solid", borderColor: "black", borderRadius: "5px" }}>
                <div className="row">
                    <div className="col-sm-2" style={{ marginLeft: "-32%" }}>
                        <FontAwesomeIcon icon="arrow-down" size="lg" className="color-light" />
                    </div>
                    <div className="col-sm-8"><div>SEARCH</div></div>
                    <div className="col-sm-2" style={{ marginRight: "-35%" }}>
                        <FontAwesomeIcon icon="arrow-down" size="lg" className="color-light" />
                    </div>
                </div>

                <div className="row">
                    <div className="col-sm-2" style={{ marginLeft: "-32%" }}>
                        <FontAwesomeIcon icon="arrow-up" size="lg" className="color-contrast" />
                    </div>
                    <div className="col-sm-8"><div>ENGINE</div></div>
                    <div className="col-sm-2" style={{ marginRight: "-35%" }}>
                        <FontAwesomeIcon icon="arrow-up" size="lg" className="color-contrast" />
                    </div>
                </div>
                <div className="row">
                    <div className="col-sm-2" style={{ marginLeft: "-32%" }}>
                        <FontAwesomeIcon icon="arrow-down" size="lg" className="color-light" />
                    </div>
                    <div className="col-sm-8"><div>RANKING</div></div>
                    <div className="col-sm-2" style={{ marginRight: "-35%" }}>
                        <FontAwesomeIcon icon="arrow-down" size="lg" className="color-light" />
                    </div>
                </div>
            </div>
        </div>
    )
}

export default Icon;