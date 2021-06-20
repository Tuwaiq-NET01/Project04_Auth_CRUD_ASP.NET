import React, { useState } from 'react';
import { Redirect } from "react-router-dom";
import { Row, Col, Card, CardImg,
    CardBody, CardTitle, Button } from 'reactstrap';

// https://cdn.iconscout.com/icon/premium/png-512-thumb/cv-187-634524.png
function ResumeListItem(props) {
    const [edit, setEdit] = useState(false);
    const [preview, setPreview] = useState(false);

    if(edit) {
        return (
            <Redirect to={{
                pathname: "/editor",
                state: { resume: props.resume, edit: true }
            }}/>
        )
    } else if(preview) {
        return(
            <Redirect to={{
                pathname: "/preview",
                state: { resume: props.resume }
            }}/>
        )
    }

    return (
        <Card body inverse style={{backgroundColor: '#5C5D69', borderColor: '#484C55' }}>
            <Row>
                <Col xs="4">
                    <CardImg style={{width: "124px"}} src="https://cdn.iconscout.com/icon/premium/png-512-thumb/cv-187-634524.png" alt="CV Icon" />
                </Col>
                <Col xs="4">
                    <CardBody style={{height: "100%"}}>
                        <CardTitle className="mt-auto" tag="h5">{props.resume.title}</CardTitle>
                        <div style={{ display: "flex",alignSelf: "right" }}></div>
                        <Button>Preview</Button>
                        <Button onClick={() => setEdit(true)}>Edit</Button>
                        <Button onClick={() => props.delete(props.resume, props.index)}>Delete</Button>
                    </CardBody>
                </Col>
            </Row>
        </Card>
    )
}

export default ResumeListItem;
