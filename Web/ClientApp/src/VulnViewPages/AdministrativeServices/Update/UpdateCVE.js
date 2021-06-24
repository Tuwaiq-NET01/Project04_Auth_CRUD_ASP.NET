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

export default function UpdateCVE() {
    const [searchBtnText, setSearchBtnText] = useState("Search")
    const [updateBtnText, setUpdateBtnText] = useState("Update")


    const [CNAs, setCNAs] = useState(null)
    const [searchId, setSearchId] = useState('1234')
    const [searchYear, setSearchYear] = useState(2021)

    const [enableSearch, setEnableSearch] = useState(true)

    const [id, setId] = useState('')
    const [year, setYear] = useState('')
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



    const searchCve = () => {
        if (searchBtnText === "Clear") {
            setEnableSearch(true)
            setId('')
            setYear('')
            setCvss2(0)
            setCvss3(0)
            setDescription('')
            setSearchId(id)
            setSearchYear(year)
            setSearchBtnText("Search")
        }
        else {
            setSearchBtnText(<img src={loading} style={{ width: "2rem" }} />)
            axios.get(`${endpoint}/API/CVEs?cve-id=${searchId}&cve-year=${searchYear}`)
                .then(res => {
                    if (res.data.length > 0) {
                        setId(res.data[0].id)
                        setYear(res.data[0].year)
                        setCvss2(res.data[0].cvsSv2Impact == 255 ? 0 : res.data[0].cvsSv2Impact / 10)
                        setCvss3(res.data[0].cvsSv3Impact == 255 ? 0 : res.data[0].cvsSv3Impact / 10)
                        setCna(res.data[0].cna)
                        setDescription(res.data[0].description)
                        setEnableSearch(false)
                        setId(searchId)
                        setYear(searchYear)
                        setSearchBtnText("Clear")
                    } else {
                        console.log(err.response);
                        setSearchBtnText("Search")
                        toast(`CVE Not Found!`, {
                            transition: Slide,
                            closeButton: true,
                            autoClose: 5000,
                            position: 'bottom-center',
                            type: 'error'
                        });
                    }
                })
                .catch(err => {
                    console.log(err.response);
                    setSearchBtnText("Search")
                    toast(`CVE Not Found`, {
                        transition: Slide,
                        closeButton: true,
                        autoClose: 5000,
                        position: 'bottom-center',
                        type: 'error'
                    });
                })
        }
    }

    const updateCve = () => {
        setUpdateBtnText(<img src={loading} style={{ width: "2rem" }} />)
        axios.put(`${endpoint}/API/CVEs?cve-id=${searchId}&cve-year=${searchYear}`, {
            year: year,
            id: id,
            description: description,
            cvssv2Impact: cvss2 * 10,
            cvssv3Impact: cvss3 * 10,
            cna: cna
        })
            .then(res => {
                console.log(res);
                setUpdateBtnText("Update")
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
                setUpdateBtnText("Update")
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
                        <CardTitle>Update CVE Records</CardTitle>
                        <Form action="#">

                            <Row className="justify-content-center">
                                <Col sm={6} md={8} xl={3}>
                                    <Label for="search-cve-year">CVE Number</Label>
                                    <InputGroup>
                                        <InputGroupAddon addonType="prepend">
                                            <InputGroupText>CVE-</InputGroupText>
                                        </InputGroupAddon>
                                        <Input name="search-cve-year" placeholder="2021" id="search-cve-year-input" onChange={e => setSearchYear(e.target.value)} disabled={!enableSearch} />
                                        <InputGroupAddon addonType="append">
                                            <InputGroupText>-</InputGroupText>
                                        </InputGroupAddon>
                                        <Input name="search-cve-id" placeholder="1234" id="search-cve-id-input" onChange={e => setSearchId(e.target.value)} disabled={!enableSearch} />
                                    </InputGroup>
                                </Col>
                            </Row>
                            <Row className="center text-center">
                                <Col >
                                    <Button color="primary" className="mt-2 mb-3 btn btn-lg" onClick={searchCve} >{searchBtnText}</Button>
                                </Col>
                            </Row>




                            <Row form>
                                <Col sm={6} md={6} xl={3}>
                                    <Label for="cve-year">CVE Number</Label>
                                    <InputGroup>
                                        <InputGroupAddon addonType="prepend">
                                            <InputGroupText>CVE-</InputGroupText>
                                        </InputGroupAddon>
                                        <Input name="cve-year" value={year} onChange={e => setYear(e.target.value)} disabled />
                                        <InputGroupAddon addonType="append">
                                            <InputGroupText>-</InputGroupText>
                                        </InputGroupAddon>
                                        <Input name="cve-id" value={id} onChange={e => setId(e.target.value)} disabled />
                                    </InputGroup>
                                </Col>

                                <Col sm={6} md={6} xl={3}>
                                    <FormGroup>
                                        <Label for="exampleCustomSelect">Numbering Authority</Label>
                                        <CustomInput type="select" value={cna} id="exampleCustomSelect"
                                            name="customSelect" onChange={e => setCna(e.target.value)} disabled={enableSearch ? true : false}>
                                            {CNAs}
                                        </CustomInput>
                                    </FormGroup>
                                </Col>

                                <Col sm={6} md={6} xl={3}>
                                    <FormGroup>
                                        <Label for="cve-cvss2">CVSS v2 Score <span className={"text-secondary"}>(Optional)</span></Label>
                                        <Input type="number" value={cvss2} min={0} max={10} step={0.1} name="cve-cvss2" onChange={e => setCvss2(e.target.value)} disabled={enableSearch ? true : false} />
                                    </FormGroup>
                                </Col>

                                <Col sm={6} md={6} xl={3}>
                                    <FormGroup>
                                        <Label for="cve-cvss3">CVSS v3 Score <span className={"text-secondary"}>(Optional)</span></Label>
                                        <Input type="number" min={0} max={10} step={0.1} name="cve-cvss3" value={cvss3} onChange={e => setCvss3(e.target.value)} disabled={enableSearch ? true : false} />
                                    </FormGroup>
                                </Col>


                                <Col md={12}>
                                    <FormGroup>
                                        <Label for="cve-description">Description <span className={"text-secondary"}>(Optional)</span></Label>
                                        <Input type="textarea" name="cve-description" value={description} onChange={e => setDescription(e.target.value)} disabled={enableSearch ? true : false} />
                                    </FormGroup>
                                </Col>


                            </Row>

                            <div className="center text-center">
                                <Button color="primary btn btn-lg" className="mt-2" onClick={updateCve}
                                    disabled={enableSearch ? true : false} >{updateBtnText}</Button>
                            </div>
                        </Form>

                    </CardBody>
                </Card>
            </ReactCSSTransitionGroup>
        </Fragment>
    )
}
