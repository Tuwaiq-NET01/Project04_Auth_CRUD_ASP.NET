import axios from 'axios';
import React, {useState, useEffect} from 'react'
import Course from '../Components/Course'

export default function AvailableCourses() {
    const [course, setCourse] = useState([]);

    useEffect(() => {
        callApi();        
    }, []);

    const callApi = async () => {
        await axios.get('http://localhost:5000/api/courses')
        .then(res => {
            setCourse(res.data);
        })
        .catch(err => console.log(err));
    }

    const mappedCourses = course.map(obj => {
        return (<Course course={obj} />)
    });

    return (
        <div className="my-5 container">
              <div className="d-flex mb-3 justify-content-between flex-wrap">
                  { mappedCourses }
              </div>
        </div>
    )
}
