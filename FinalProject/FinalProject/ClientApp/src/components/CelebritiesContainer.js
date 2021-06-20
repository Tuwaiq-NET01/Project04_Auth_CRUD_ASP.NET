import React, {useState,useEffect } from 'react'
import axios from 'axios'
import SearchArea from './SearchArea'
import CelebritiesList from './CelebritiesList'
import Header from './Header'
export default function CelebritiesContainer(props) {

    const [Celebrities, setCelebrities] = useState([])
    const [searchFiled, setSearchFiled] = useState('')


    useEffect(() => {
        axios({
            method: "get",
            url: "https://localhost:5001/api/Celebrities" 
        }).then((response) => {
            setCelebrities([...response.data])
           // this.setState({ books: [...response.data.items] })
            //console.log("res", [...response.data][0]);
        }).catch((e) => {
            console.log("error", e);
        })
    }, [])

    const  handleData = (e) => {
        // e.preventDefault();
        // axios({
        //     method: "get",
        //     url: "https://localhost:5001/api/Celebrities" + searchFiled
        // }).then((response) => {
        //     setCelebrities([...response.data])
          
        //     console.log("res", [...response.data.items]);
        // }).catch((e) => {
        //     console.log("error", e);
        // })

    }

    const handleSearch = (e) => {
        console.log(e.target.value);
        setSearchFiled(e.target.value)
    }

    return (
        <div>
             <Header  handleSearch={handleSearch} handleData={handleData}  />
              
              <CelebritiesList Celebrities={Celebrities}/>
        </div>
    )
}
