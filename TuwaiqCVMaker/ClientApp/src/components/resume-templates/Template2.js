import React, { PureComponent } from 'react';
import { Row, Col, Card, CardImg, ListGroup, ListGroupItem, Label, Progress } from 'reactstrap';

class Template2 extends PureComponent {
    constructor(props) {
        super(props);
        this.resume = props.resume;
        this.progress = [
            (<><div className="text-center">25%</div>
            <Progress value={25} /></>),
            (<><div className="text-center">50%</div>
            <Progress value={50} /></>),
            (<><div className="text-center">75%</div>
            <Progress value={75} /></>),
            (<><div className="text-center">100%</div>
            <Progress value={100} /></>)
        ];
    }
    render() {
        return (
            <div className="resume">
                <Row className="text-center resume-header">
                    <Col xs={{size: 4, offset: 4}}>
                        <h1 className="mt-3">{this.resume.name}</h1>
                        <h5>Graphic Designer &amp; Web developer</h5>
                    </Col>
                    <Col xs="4">
                        <Card>
                            <CardImg top width="100%" src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQwhgREKJpawVaEkD5aRXudpG-Q3gec7qWcSA&usqp=CAU" alt="Card image cap" />
                        </Card>
                    </Col>
                </Row>
                <Row className="resume-body mt-5">
                    <Col xs="7" className="pr-0">
                        <div className="resume-introduction">
                            <div className="ml-2">
                                <Label><h2>Introduction</h2></Label>
                            </div>
                            <hr/>
                            <div className="ml-2">
                                <p className="resume-introduction-text">{this.resume.introduction}</p>
                            </div>
                        </div>
                    </Col>
                    <Col xs="5" className="pl-0">
                        <div className="resume-details">
                            <Label><h2>Details</h2></Label>
                            <hr/>
                            <div>
                                <Label><h4>Email: </h4></Label> <span>{this.resume.email}</span>
                            </div>
                            <div>
                                <Label><h4>Phone: </h4></Label> <span>{this.resume.phone}</span>
                            </div>
                            <div>
                                <Label><h4>Education: </h4></Label> <span>{this.resume.education}</span>
                            </div>
                        </div>
                    </Col>
                </Row>
                <Row className="resume-body">
                    <Col xs={{size: 1, offset: 3}}>
                        <Label><h2>Skills</h2></Label>
                    </Col>
                </Row>
                <Row className="resume-body">
                    <Col xs={{size: 6, offset: 3}}>
                        <ListGroup>
                        {
                            this.resume.skills.map((skill, index) => {
                                return <ListGroupItem key={index}>{skill.name} {this.progress[Math.floor(Math.random() * 4)]}</ListGroupItem>;
                            })
                        }
                        </ListGroup>
                    </Col>
                </Row>
            </div>
        );
    }
}

export default Template2;
