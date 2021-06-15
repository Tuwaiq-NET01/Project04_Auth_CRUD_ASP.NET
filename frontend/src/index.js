import React from 'react'
import ReactDOM from 'react-dom'
import './index.css'
import App from './App'
import axios from 'axios'

axios.defaults.baseURL = 'https://localhost:5001'
axios.defaults.headers.common['Authorization'] =
  'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiYWRtaW4iLCJqdGkiOiJhMzYzNzVjYS01MzQzLTQ4ZDUtYjBhZi0yMDA5OTc0MzcwMjAiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJBZG1pbiIsImV4cCI6MTYyMzg0NDcxMiwiaXNzIjoiSXNzdWVyIiwiYXVkIjoiQXVkaWVuY2UifQ.F3PAAngPmTSwB_Cia1UKI2A6CfkIu1vc1zxf0ml8mTY'
axios.defaults.headers.post['Content-Type'] = 'application/json'

ReactDOM.render(<App />, document.getElementById('root'))
