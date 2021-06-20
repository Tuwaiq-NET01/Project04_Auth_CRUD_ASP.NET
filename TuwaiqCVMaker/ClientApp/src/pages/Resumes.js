import React, { useState, useEffect } from 'react';
import { Redirect } from "react-router-dom";
import { Button, Row } from 'reactstrap';
import { useLoading, BallTriangle } from '@agney/react-loading';
import authService from '../components/api-authorization/AuthorizeService';
import ResumeListItem from '../components/ResumeListItem';
import axios from 'axios';

function Resumes() {
    const [resumes, setResumes] = useState([]);
    const [loading, setLoading] = useState(true);
    const [redirect, setRedirect] = useState(false);
    
    const { containerProps, indicatorEl } = useLoading({
        loading: true,
        indicator: <BallTriangle color="#343a40" width="50%" />,
    });

    useEffect(() => {
        loadResumes();
    }, []);

    if(redirect) {
        return <Redirect to="/editor" />
    }

    const loadResumes = async () => {
        const token = await authService.getAccessToken();
        axios.get(process.env.REACT_APP_API + "resumes", { headers: !token ? {} : {'Authorization': `Bearer ${token}`} })
        .then(res => {
            setResumes(res.data);
            setLoading(false);
        }).catch(err => console.log(err));
    }

    const deleteResume = async (resume, index) => {
        // delete from react
        const temp = resumes;
        temp.splice(index, 1);
        setResumes([...temp]);

        // delete from backend
        const token = await authService.getAccessToken();
        axios.delete(process.env.REACT_APP_API + "resumes/" + resume.id, { headers: !token ? {} : {'Authorization': `Bearer ${token}`} })
    }

    const loadingAnimation = (
        <section className="text-center" {...containerProps}>
            {indicatorEl}
        </section>
    );

    const content = (
        resumes.length == 0 ? <h1>You don't have any resumes yet.</h1> :
        resumes.map((resume, index) => {
            return <Row key={index}><ResumeListItem key={index} resume={resume} index={index} delete={deleteResume}/></Row>
        })
    );

    return (
        <div className="text-center">
            <h1>Your resumes</h1>
            <Button className="mb-5" onClick={() => setRedirect(true)} >Create resume</Button>
            {
                loading ?
                loadingAnimation
                :
                content
            }
        </div>
    );
}

export default Resumes;
