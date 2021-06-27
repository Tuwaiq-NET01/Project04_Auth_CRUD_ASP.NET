import React from "react"
import ReactDOM from "react-dom"
import "./index.css"
import App from "./App"
import axios from "axios"

axios.defaults.baseURL = "https://bitchunkapi.herokuapp.com"
axios.defaults.headers.post["Content-Type"] = "application/json"

ReactDOM.render(<App />, document.getElementById("root"))
