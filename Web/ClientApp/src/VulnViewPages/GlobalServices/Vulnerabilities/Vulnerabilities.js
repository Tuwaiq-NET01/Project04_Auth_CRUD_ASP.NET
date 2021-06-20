import React, { Fragment, useState } from 'react'
import {
    Card, CardTitle, CardBody, Row, Col, Label, InputGroup,
    InputGroupAddon, InputGroupText, Input, FormGroup, CustomInput,
    Table, Button
} from 'reactstrap'
import ReactCSSTransitionGroup from 'react-addons-css-transition-group';
import PageTitle from '../../../Layout/AppMain/PageTitle'
import axios from 'axios';
const endpoint = process.env.VULNVIEW_API_ENDPOINT

export default function Vulnerabilities() {
    const [searchId, setSearchId] = useState('1234')
    const [searchYear, setSearchYear] = useState(2021)
    const [id, setId] = useState('')
    const [year, setYear] = useState('')
    const [minCvss2, setMinCvss2] = useState(0)
    const [maxCvss2, setMaxCvss2] = useState(0)
    const [minCvss3, setMinCvss3] = useState(0)
    const [maxCvss3, setMaxCvss3] = useState(0)
    const [fromDate, setFromDate] = useState(0)
    const [toDate, setToDate] = useState(0)
    const [cna, setCna] = useState(2)
    const [counter, setCounter] = useState(1)
    const [init, setInit] = useState(false)
    const [vulnList, setVulnList] = useState([])
    const [CNAs, setCNAs] = useState(null)
    const [CNAsDict, setCNAsDict] = useState({})

    const addToVulnList = (vulns) => {
        for (let i = 0; i < vulns.length; i++) {
            setVulnList(vulnList => [...vulnList, <tr key={counter + i}>
                <td>{counter + i}</td>
                <td>CVE-{vulns[i].year}-{vulns[i].id}</td>
                <td>{vulns[i].createdAt.split("T")[0]}</td>
                <td>{vulns[i].updatedAt.split("T")[0]}</td>
                <td>{vulns[i].cvsSv2Impact == 255 ? "-" : vulns[i].cvsSv2Impact / 10}</td>
                <td>{vulns[i].cvsSv3Impact == 255 ? "-" : vulns[i].cvsSv3Impact / 10}</td>
                <td>{vulns[i].cnaNavigation.name.trim()}</td>
            </tr>])
            // console.log(CNAsDict[vulns[i].cna]);
            setCounter(counter => counter + 1)
        }

    }


    if (!init) {
        setInit(true)
        let CNAsPromise = axios.get(`${endpoint}/API/CNAs`)
            .then(res => {
                let tmpObj = {}
                res.data.forEach(item => tmpObj[item.id] = item.name.trim());
                // console.log(tmpObj[88]);
                setCNAsDict(tmpObj)
                setCNAs([<option key={-1} value="1">Any</option>, ...res.data.map((cna, key) => <option key={key} value={cna.id}>{cna.name.trim()}</option>)])
            })
        Promise.all([CNAsPromise]).then(axios.get(`${endpoint}/API/CVEs`).then(res => addToVulnList(res.data)))
    }

    const paginate = () => {
        axios.get(`${endpoint}/API/CVEs?offset=${counter}`).then(res => addToVulnList(res.data))
    }

    const search = () => {
        setCounter(1)
        setVulnList([])
        axios.get(`${endpoint}/API/CVEs?` +
            `${id > 0 ? `cve-id=${id}&` : ""}` +
            `${year > 0 ? `cve-year=${year}&` : ""}` +
            `${minCvss2 > 0 ? `from-cvss2=${minCvss2}&` : ""}` +
            `${maxCvss2 > 0 ? `from-cvss2=${maxCvss2}&` : ""}` +
            `${minCvss3 > 0 ? `from-cvss3=${minCvss3}&` : ""}` +
            `${maxCvss3 > 0 ? `from-cvss3=${maxCvss3}&` : ""}` +
            `${fromDate > 0 ? `from-date=${fromDate}&` : ""}` +
            `${toDate > 0 ? `to-date=${toDate}&` : ""}` +
            `${cna > 2 ? `cna=${cna}&` : ""}` +
            `x=1`).then(res => addToVulnList(res.data))
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
                <PageTitle
                    heading="Vulnerabilities"
                    subheading="Search for thousands of historical vulnerability records affecting all industries"
                    icon="fas fa-bug"
                />
                <Card className="main-card mb-3">
                    <CardBody>
                        <CardTitle>Search CVE Records</CardTitle>
                        <Row>
                            <Col sm={6} md={8} xl={3}>
                                <Label for="search-cve-year">CVE Number</Label>
                                <InputGroup>
                                    <InputGroupAddon addonType="prepend">
                                        <InputGroupText>CVE-</InputGroupText>
                                    </InputGroupAddon>
                                    <Input name="search-cve-year" placeholder="" id="search-cve-year-input" value={year} onChange={e => setYear(e.target.value)} />
                                    <InputGroupAddon addonType="append">
                                        <InputGroupText>-</InputGroupText>
                                    </InputGroupAddon>
                                    <Input name="search-cve-id" placeholder="" id="search-cve-id-input" value={id} onChange={e => setId(e.target.value)} />
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
                                    <Label for="min-cve-cvss2">Min CVSS v2 Score <span className={"text-secondary"}>(Optional)</span></Label>
                                    <Input value={minCvss2} onChange={e => setMinCvss2(e.target.value)} type="number" min={0} max={10} step={0.1} name="min-cve-cvss2" />
                                </FormGroup>
                            </Col>

                            <Col sm={6} md={6} xl={3}>
                                <FormGroup>
                                    <Label for="max-cve-cvss2">Max CVSS v2 Score <span className={"text-secondary"}>(Optional)</span></Label>
                                    <Input value={maxCvss2} onChange={e => setMaxCvss2(e.target.value)} type="number" min={0} max={10} step={0.1} name="max-cve-cvss2" />
                                </FormGroup>
                            </Col>

                            <Col sm={6} md={6} xl={3}>
                                <FormGroup>
                                    <Label for="min-cve-cvss3">Min CVSS v3 Score <span className={"text-secondary"}>(Optional)</span></Label>
                                    <Input value={minCvss3} onChange={e => setMinCvss3(e.target.value)} type="number" min={0} max={10} step={0.1} name="min-cve-cvss3" />
                                </FormGroup>
                            </Col>

                            <Col sm={6} md={6} xl={3}>
                                <FormGroup>
                                    <Label for="max-cve-cvss3">Max CVSS v3 Score <span className={"text-secondary"}>(Optional)</span></Label>
                                    <Input value={maxCvss3} onChange={e => setMaxCvss3(e.target.value)} type="number" min={0} max={10} step={0.1} name="max-cve-cvss3" />
                                </FormGroup>
                            </Col>


                            <Col sm={6} md={6} xl={3}>
                                <FormGroup>
                                    <Label for="from-date">From Date <span className={"text-secondary"}>(Optional)</span></Label>
                                    <Input value={fromDate} onChange={e => setFromDate(e.target.value)} type="date" name="from-date" />
                                </FormGroup>
                            </Col>


                            <Col sm={6} md={6} xl={3}>
                                <FormGroup>
                                    <Label for="to-date">From Date <span className={"text-secondary"}>(Optional)</span></Label>
                                    <Input value={toDate} onChange={e => setToDate(e.target.value)} type="date" name="to-date" />
                                </FormGroup>
                            </Col>

                            <Col>
                                <Button className="mt-3 btn btn-lg" color="primary" onClick={() => { setCounter(1); search() }}>Search</Button>
                            </Col>

                            {/* <Col>
                                <Button outline style={{ fontSize: 20 }} className="mb-2 mr-2 border-0 btn-transition btn-lg"
                                    color="link"><i className="fas fa-filter"></i></Button>
                            </Col> */}
                        </Row>
                    </CardBody>
                </Card>

                <Card>
                    <CardBody>
                        <Table responsive className="mb-0">
                            <thead>
                                <tr>
                                    <th>#</th>
                                    <th>CVE Number</th>
                                    <th>Creation Date</th>
                                    <th>Last Update</th>
                                    <th>CVSS v2 Score</th>
                                    <th>CVSS v3 Score</th>
                                    <th>Numbering Authority</th>
                                </tr>
                            </thead>
                            <tbody>
                                {/* <tr>
                                    <th scope="row">1</th>
                                    <td>sTable cell</td>
                                    <td>Table cell</td>
                                    <td>Table cell</td>
                                    <td>Table cell</td>
                                    <td>Table cell</td>
                                    <td>Table cell</td>
                                </tr>
                                <tr>
                                    <th scope="row">2</th>
                                    <td>Table cell</td>
                                    <td>Table cell</td>
                                    <td>Table cell</td>
                                    <td>Table cell</td>
                                    <td>Table cell</td>
                                    <td>Table cell</td>
                                </tr>
                                <tr>
                                    <th scope="row">3</th>
                                    <td>Table cell</td>
                                    <td>Table cell</td>
                                    <td>Table cell</td>
                                    <td>Table cell</td>
                                    <td>Table cell</td>
                                    <td>Table cell</td>
                                </tr> */}
                                {vulnList}
                            </tbody>
                        </Table>
                        <div className="d-flex justify-content-center">
                            <Button className="mt-3 btn btn-lg" color="primary" onClick={paginate}>Next</Button>
                        </div>
                    </CardBody>
                </Card>
            </ReactCSSTransitionGroup>
        </Fragment>
    )
}
