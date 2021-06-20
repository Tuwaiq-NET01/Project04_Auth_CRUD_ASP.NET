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

export default function InsertCVE() {
    const [btnText, setBtnText] = useState("Create")
    const [CNAs, setCNAs] = useState(null)

    const [id, setId] = useState('0001')
    const [year, setYear] = useState(2021)
    const [cvss2, setCvss2] = useState(0)
    const [cvss3, setCvss3] = useState(0)
    const [description, setDescription] = useState('')
    const [cna, setCna] = useState(2)

    const endpoint = process.env.VULNVIEW_API_ENDPOINT
    if (CNAs === null) {
        setCNAs([])
        axios.get(`${endpoint}/API/CNAs`)
            .then(res => {
                setCNAs(res.data.map((cna, key) => <option key={key} value={cna.id}>{cna.name}</option>))
            })
    }

    const insertCve = () => {
        setBtnText(<img src={loading} style={{ width: "2rem" }} />)
        axios.post(`${endpoint}/API/CVEs`, {
            year: year,
            id: id,
            description: description,
            cvssv2Impact: cvss2 * 10,
            cvssv3Impact: cvss3 * 10,
            cna: cna
        })
            .then(res => {
                console.log(res);
                setBtnText("Create")
                toast("A new CVE record was successfully created!", {
                    transition: Slide,
                    closeButton: true,
                    autoClose: 5000,
                    position: 'bottom-center',
                    type: 'success'
                });
            })
            .catch(err => {
                console.log(err.response);
                setBtnText("Create")
                toast(`An error has occured (${err.response.statusText})!`, {
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
                        <CardTitle>Create CVE Records</CardTitle>
                        <Form action="#">
                            <Row form>
                                <Col sm={6} md={6} xl={3}>
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

                                <Col sm={6} md={6} xl={3}>
                                    <FormGroup>
                                        <Label for="exampleCustomSelect">Numbering Authority</Label>
                                        <CustomInput type="select" id="exampleCustomSelect"
                                            name="customSelect" onChange={e => setCna(e.target.value)}>
                                            {CNAs}
                                        </CustomInput>
                                    </FormGroup>
                                </Col>

                                <Col sm={6} md={6} xl={3}>
                                    <FormGroup>
                                        <Label for="cve-cvss2">CVSS v2 Score <span className={"text-secondary"}>(Optional)</span></Label>
                                        <Input type="number" min={0} max={10} step={0.1} name="cve-cvss2" id="cve-cvss2" onChange={e => setCvss2(e.target.value)} />
                                    </FormGroup>
                                </Col>

                                <Col sm={6} md={6} xl={3}>
                                    <FormGroup>
                                        <Label for="cve-cvss3">CVSS v3 Score <span className={"text-secondary"}>(Optional)</span></Label>
                                        <Input type="number" min={0} max={10} step={0.1} name="cve-cvss3" id="cve-cvss3" onChange={e => setCvss3(e.target.value)} />
                                    </FormGroup>
                                </Col>


                                <Col md={12}>
                                    <FormGroup>
                                        <Label for="cve-description">Description <span className={"text-secondary"}>(Optional)</span></Label>
                                        <Input type="textarea" name="cve-description" id="cve-description" onChange={e => setDescription(e.target.value)} />
                                    </FormGroup>
                                </Col>


                            </Row>

                            <div className="center text-center">
                                <Button color="primary btn btn-lg" className="mt-2" onClick={insertCve} >{btnText}</Button>
                            </div>
                        </Form>

                    </CardBody>
                </Card>
            </ReactCSSTransitionGroup>
        </Fragment>
    )
}
