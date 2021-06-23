import React, { PureComponent } from 'react';
import { Row, Col, Card, CardImg, ListGroup, ListGroupItem, Label, Progress } from 'reactstrap';

class Template2 extends PureComponent {
    constructor(props) {
        super(props);
        this.resume = props.resume;
    }
    render() {
        return (
            <div className="resume">
                <Row className="text-center resume-header">
                    <Col xs={{size: 4, offset: 4}}>
                        <h1 className="mt-3">{this.resume.name}</h1>
                        <h5>{this.resume.jobDescription}</h5>
                    </Col>
                    <Col xs="4">
                        <Card>
                            <CardImg top width="100%" src={this.resume.personalPicture} alt="Card image cap" />
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
                <Row>
                    <Col>
                        <hr/>
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
                                return (
                                    <ListGroupItem key={index}>
                                        {skill.name}
                                        <div className="text-center">{25 * skill.level}%</div>
                                        <Progress value={25 * skill.level} />
                                    </ListGroupItem>
                                );
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
