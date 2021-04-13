import React, { useEffect, useState } from 'react';
import SearchQuery from './components/SearchQuery';
import './custom.css'


const App = () => {
    const [data, setData] = useState("");

    function loadDefaultQuery() {
        console.log("running fetch");
        const fetchQuery = fetch("/query", {
            method: "GET"
        })
            .then(response => response.json())
            .then(data => setData(data))
            .catch(error => console.error("unable to get default values. ", error));
    }

    useEffect(() => {
        loadDefaultQuery();

    }, []);
    return (
        <div>
            {data !== "" ?
                <SearchQuery data={data} />
                : null}
        </div>
    );

}
export default App;