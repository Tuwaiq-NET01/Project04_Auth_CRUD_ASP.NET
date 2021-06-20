import React, {useState, useEffect} from 'react'

export default function StudentInfo(props) {
    const [id, setId] = useState(localStorage.getItem('ASKid'));
    const [username, setUsername] = useState(localStorage.getItem('ASKusername'));
    const [email, setEmail] = useState(localStorage.getItem('ASKemail'));
    const [gender, setGender] = useState(localStorage.getItem('ASKgender'));

    let temp = username;

    const handleChange = async (e) => {
        if(temp !== username) console.log('changed!');
    }

    return (
        <div className="container text-center my-5 p-3">
            <h2 className="mb-5">Student's Information</h2>

            <div class="my-2 mt-2">
                <label className="w-50 ">ID</label>
                <input className="" type="text" value={id} disabled />
            </div>

            <div class="my-2">
                <label className="w-50">UserName</label>
                <input className="" onChange={(e) => {}} type="text" value={username} />
            </div>

            <div class="my-2">
                <label className="w-50">Email</label>
                <input className="" type="text" value={email} disabled/>
            </div>

            <div class="my-2"> 
                <label className="w-50">Gender</label>
                <input className="" onChange={() => {}} type="text" value={gender} />
            </div>

            <button onClick={handleChange} className="btn btn-primary mt-5 ml-5">Update Profile</button>
        </div>
    )
}
