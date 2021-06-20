import axios from 'axios';
import React, {useState, useEffect} from 'react'
import Course from '../Components/Course';


export default function MyLearning() {
    const [id, setId] = useState(localStorage.getItem('ASKid'));
    const [course, setCourse] = useState([]);

    useEffect(() => {
        callApi();        
    }, []);

    const callApi = async () => {
        await axios.get(`http://localhost:5000/api/myLearning/${id}`)
        .then(res => {  
            setCourse(res.data);
        })
        .catch(err => console.log(err));
    }

    const mappedCourses = course.map(obj => {
        return (<Course course={obj.courseModel} />)
    });

    return (
        <div>
            {
                id !== null 
                ?
                <div className="my-5 container">
                    <h1 className="my-5">Courses you are enrollrd in.</h1>
                    <div className="d-flex mb-3 justify-content-between flex-wrap">
                        { mappedCourses }
                    </div>
                </div>
                :
                <h1>Make sure your logged in..</h1>
            }
        </div>
    )
}
