import React from 'react'
export default function SearchArea(props) {
    return (
        <div className="search-area">
        <form  onSubmit={props.handleData}>
            <input onChange={props.handleSearch}></input>
            <button > show</button>
        </form>
    </div>
    )
}
