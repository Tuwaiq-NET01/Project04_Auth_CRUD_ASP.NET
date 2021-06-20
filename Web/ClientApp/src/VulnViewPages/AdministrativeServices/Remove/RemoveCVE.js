import React, { Fragment, useState, useEffect } from 'react'
import ReactCSSTransitionGroup from 'react-addons-css-transition-group';
import {
    Col, Row, Card, CardBody,
    CardTitle, Button, Form, FormGroup, Label, Input,
    InputGroup, InputGroupAddon, InputGroupText, CustomInput
} from 'reactstrap';
import loading from '../../../assets/utils/images/loading.gif'
import axios from 'axios'
import { toast, Slide } from 'react-toastify';

export default function RemoveCVE() {
    const [btnText, setBtnText] = useState("Delete")
    const [id, setId] = useState('0001')
    const [year, setYear] = useState(2021)
    const endpoint = process.env.VULNVIEW_API_ENDPOINT


    const insertCve = () => {
        setBtnText(<img src={loading} style={{ width: "2rem" }} />)
        axios.delete(`${endpoint}/API/CVEs?cve-id=${id}&cve-year=${year}`)
            .then(res => {
                console.log(res);
                setBtnText("Delete")
                toast("CVE record was successfully removed!", {
                    transition: Slide,
                    closeButton: true,
                    autoClose: 5000,
                    position: 'bottom-center',
                    type: 'success'
                });
            })
            .catch(err => {
                console.log(err.response);
                setBtnText("Delete")
                toast(`An error has occured (${err.response.statusText})`, {
                    transition: Slide,
                    closeButton: true,
                    autoClose: 5000,
                    position: 'bottom-center',
                    type: 'error'
                });
            })
    }

    return (
        <Fragment>
            <ReactCSSTransitionGroup
                component="div"
                transitionName="TabsAnimation"
                transitionAppear={true}
                transitionAppearTimeout={0}
                transitionEnter={false}
                transitionLeave={false}>
                <Card className="main-card mb-3">
                    <CardBody>
                        <CardTitle>Remove CVE Records</CardTitle>
                        <Row className="justify-content-center">
                            <Col sm={6} md={8} xl={3}>
                                <Label for="cve-year">CVE Number</Label>
                                <InputGroup>
                                    <InputGroupAddon addonType="prepend">
                                        <InputGroupText>CVE-</InputGroupText>
                                    </InputGroupAddon>
                                    <Input name="cve-year" placeholder="2021" id="cve-year-input" onChange={e => setYear(e.target.value)} />
                                    <InputGroupAddon addonType="append">
                                        <InputGroupText>-</InputGroupText>
                                    </InputGroupAddon>
                                    <Input name="cve-id" placeholder="0001" id="cve-id-input" onChange={e => setId(e.target.value)} />
                                </InputGroup>
                            </Col>
                        </Row>
                        <Row className="center text-center">
                            <Col >
                                <Button color="danger" className="mt-2 " onClick={insertCve} >{btnText}</Button>
                            </Col>
                        </Row>

                    </CardBody>
                </Card>
            </ReactCSSTransitionGroup>
        </Fragment>
    )
}
