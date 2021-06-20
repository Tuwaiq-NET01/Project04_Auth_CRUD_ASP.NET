import React, {useState, useEffect} from 'react'
import Feed from '../Components/Feed'

export default function FeedPage(props) {
    const [id, setId] = useState(localStorage.getItem('ASKid'));
    const [username, setUsername] = useState(localStorage.getItem('ASKusername'));
    const [email, setEmail] = useState(localStorage.getItem('ASKemail'));
    const [gender, setGender] = useState(localStorage.getItem('ASKgender'));

    return (
        <div className="">
            <Feed />
        </div>
    )
}