import React from 'react'
import 'bootstrap/dist/css/bootstrap.min.css';
import SearchArea from './SearchArea';
export default function Header(props) {
    return (
        <div>

            <nav class="navbar navbar-dark bg-dark navbar-expand-sm">
                <a class="navbar-brand" href="#">
                    {/* <img src="https://s3.eu-central-1.amazonaws.com/bootstrapbaymisc/blog/24_days_bootstrap/logo_white.png" width="30" height="30" alt="logo" /> */}
    Nojoom
  </a>
            <SearchArea handleSearch={props.handleSearch} handleData={props.handleData} />
            </nav>
        </div>
    )
}
