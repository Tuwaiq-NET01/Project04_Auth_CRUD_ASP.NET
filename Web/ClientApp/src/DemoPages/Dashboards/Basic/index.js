import React, { Component, Fragment } from "react";
import ReactCSSTransitionGroup from "react-addons-css-transition-group";
import classnames from "classnames";
import loading from "../../../assets/utils/images/loading.gif";
import axios from "axios";
import { Row, Col, Button, CardHeader, Card, CardBody, Progress, TabContent, TabPane } from "reactstrap";
import PageTitle from "../../../Layout/AppMain/PageTitle";
import { AreaChart, Area, Line, ResponsiveContainer, Bar, BarChart, ComposedChart, CartesianGrid, Tooltip, LineChart } from "recharts";
import { faAngleUp, faArrowRight, faArrowUp, faArrowLeft, faAngleDown } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import avatar1 from "../../../assets/utils/images/avatars/1.jpg";
import avatar2 from "../../../assets/utils/images/avatars/2.jpg";
import avatar3 from "../../../assets/utils/images/avatars/3.jpg";
import avatar4 from "../../../assets/utils/images/avatars/4.jpg";
require("dotenv").config();

const data = [
  { name: "Page A", uv: 4000, pv: 2400, amt: 2400 },
  { name: "Page B", uv: 3000, pv: 1398, amt: 2210 },
  { name: "Page C", uv: 2000, pv: 9800, amt: 2290 },
  { name: "Page D", uv: 2780, pv: 3908, amt: 2000 },
  { name: "Page E", uv: 1890, pv: 4800, amt: 2181 },
  { name: "Page F", uv: 2390, pv: 3800, amt: 2500 },
  { name: "Page G", uv: 3490, pv: 4300, amt: 2100 },
  { name: "Page C", uv: 2000, pv: 6800, amt: 2290 },
  { name: "Page D", uv: 4780, pv: 7908, amt: 2000 },
  { name: "Page E", uv: 2890, pv: 9800, amt: 2181 },
  { name: "Page F", uv: 1390, pv: 3800, amt: 1500 },
  { name: "Page G", uv: 3490, pv: 4300, amt: 2100 },
];

const data2 = [
  { name: "Page A", uv: 5400, pv: 5240, amt: 1240 },
  { name: "Page B", uv: 7300, pv: 4139, amt: 3221 },
  { name: "Page C", uv: 8200, pv: 7980, amt: 5229 },
  { name: "Page D", uv: 6278, pv: 4390, amt: 3200 },
  { name: "Page E", uv: 3189, pv: 7480, amt: 6218 },
  { name: "Page D", uv: 9478, pv: 6790, amt: 2200 },
  { name: "Page E", uv: 1289, pv: 1980, amt: 7218 },
  { name: "Page F", uv: 3139, pv: 2380, amt: 5150 },
  { name: "Page G", uv: 5349, pv: 3430, amt: 3210 },
];

const timeNow = new Date()
const endpoint = process.env.VULNVIEW_API_ENDPOINT;
export default class AnalyticsDashboard1 extends Component {
  constructor() {
    super();
    this.loading = <img src={loading} width="48px" />;
    this.state = {
      dropdownOpen: false,
      cveCountLastYearDifference: this.loading,
      cveTotalCount: this.loading,
      cweTotalCount: this.loading,
      cpeTotalCount: this.loading,
      cnaTotalCount: this.loading,
    };
    this.getCVEs = this.getCVEs.bind(this);
    this.getCWEs = this.getCWEs.bind(this);
    this.getCPEs = this.getCPEs.bind(this);
    this.getCNAs = this.getCNAs.bind(this);

    this.getCVEs();
    this.getCWEs();
    this.getCPEs()
    this.getCNAs()
  }

  getCVEs() {
    let fromDate = new Date();
    fromDate.setFullYear(fromDate.getFullYear() - 1);
    let thisYearVulnsCountPromise = axios
      .get(`${endpoint}/API/CVEs/Count?from-date=${fromDate.toISOString().split("T")}`)
      .then((res) => res.data);

    let oneYearAgo = new Date(fromDate);
    fromDate.setFullYear(fromDate.getFullYear() - 1);
    var lastYearVulnsCountPromise = axios
      .get(`${endpoint}/API/CVEs/Count?from-date=${fromDate.toISOString().split("T")}&to-date=${oneYearAgo.toISOString().split("T")}`)
      .then((res) => res.data);

    Promise.all([lastYearVulnsCountPromise, thisYearVulnsCountPromise]).then(
      (res) => {
        const result = (((res[1] - res[0]) / res[0]) * 100).toFixed(2);
        const jsx = (
          <div>
            Last Year <br />
            <FontAwesomeIcon icon={result >= 0 ? faAngleUp : faAngleDown} />
            <span className="pl-1">{result}%</span>
          </div>
        );
        this.setState({ cveCountLastYearDifference: jsx });
      }
    );

    axios.get(`${endpoint}/API/CVEs/Count`)
      .then((res) => this.setState({ cveTotalCount: res.data.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",") }));
  }

  getCWEs() {
    axios.get(`${endpoint}/API/CWEs/Count`)
      .then(res => this.setState({ cweTotalCount: res.data.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",") }))
  }


  getCPEs() {
    axios.get(`${endpoint}/API/CPEs/Count`)
      .then(res => this.setState({ cpeTotalCount: res.data.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",") }))
  }

  getCNAs() {
    axios.get(`${endpoint}/API/CNAs/Count`)
      .then(res => this.setState({ cnaTotalCount: res.data.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",") }))
  }

  render() {
    return (
      <Fragment>
        <ReactCSSTransitionGroup
          component="div"
          transitionName="TabsAnimation"
          transitionAppear={true}
          transitionAppearTimeout={0}
          transitionEnter={false}
          transitionLeave={false}
        >
          <div>
            <PageTitle
              heading="Main Dashboard"
              subheading="Get a holestic view on the state of vulnerabilities and weaknesses with real-time data analysis"
              icon="fas fa-home icon-gradient bg-mean-fruit"
            />
            <Row>
              <Col md="12" lg="6">
                <Card className="mb-3">
                  <CardHeader className="card-header-tab">
                    <div className="card-header-title">
                      <i className="header-icon lnr-rocket icon-gradient bg-tempting-azure">
                        {" "}
                      </i>
                      Monthly Report
                    </div>
                  </CardHeader>
                  {/* <TabContent activeTab={this.state.activeTab1}> */}
                  <TabPane tabId="11">
                    <CardBody className="pt-2">
                      <Row className="mt-3">
                        <Col md="6">
                          <div className="widget-content">
                            <div className="widget-content-outer">
                              <div className="widget-content-wrapper">
                                <div className="widget-content-left mr-3">
                                  <div className="widget-numbers fsize-3 text-muted">
                                    63%
                                  </div>
                                </div>
                                <div className="widget-content-right">
                                  <div className="text-muted opacity-6">
                                    Generated Leads
                                  </div>
                                </div>
                              </div>
                              <div className="widget-progress-wrapper mt-1">
                                <Progress
                                  className="progress-bar-sm progress-bar-animated-alt"
                                  color="danger"
                                  value="63"
                                />
                              </div>
                            </div>
                          </div>
                        </Col>
                        <Col md="6">
                          <div className="widget-content">
                            <div className="widget-content-outer">
                              <div className="widget-content-wrapper">
                                <div className="widget-content-left mr-3">
                                  <div className="widget-numbers fsize-3 text-muted">
                                    32%
                                  </div>
                                </div>
                                <div className="widget-content-right">
                                  <div className="text-muted opacity-6">
                                    Submitted Tickers
                                  </div>
                                </div>
                              </div>
                              <div className="widget-progress-wrapper mt-1">
                                <Progress
                                  className="progress-bar-sm progress-bar-animated-alt"
                                  color="success"
                                  value="32"
                                />
                              </div>
                            </div>
                          </div>
                        </Col>
                      </Row>
                      <div className="divider mt-4" />
                      <Row>
                        <Col md="6">
                          <div className="widget-content">
                            <div className="widget-content-outer">
                              <div className="widget-content-wrapper">
                                <div className="widget-content-left mr-3">
                                  <div className="widget-numbers fsize-3 text-muted">
                                    71%
                                  </div>
                                </div>
                                <div className="widget-content-right">
                                  <div className="text-muted opacity-6">
                                    Server Allocation
                                  </div>
                                </div>
                              </div>
                              <div className="widget-progress-wrapper mt-1">
                                <Progress
                                  className="progress-bar-sm progress-bar-animated-alt"
                                  color="primary"
                                  value="71"
                                />
                              </div>
                            </div>
                          </div>
                        </Col>
                        <Col md="6">
                          <div className="widget-content">
                            <div className="widget-content-outer">
                              <div className="widget-content-wrapper">
                                <div className="widget-content-left mr-3">
                                  <div className="widget-numbers fsize-3 text-muted">
                                    41%
                                  </div>
                                </div>
                                <div className="widget-content-right">
                                  <div className="text-muted opacity-6">
                                    Generated Leads
                                  </div>
                                </div>
                              </div>
                              <div className="widget-progress-wrapper mt-1">
                                <Progress
                                  className="progress-bar-sm progress-bar-animated-alt"
                                  color="warning"
                                  value="41"
                                />
                              </div>
                            </div>
                          </div>
                        </Col>
                      </Row>
                    </CardBody>
                    <div className="widget-chart p-0">
                      <div className="widget-chart-content">
                        <div className="widget-description mt-0 text-warning">
                          <FontAwesomeIcon icon={faArrowLeft} />
                          <span className="pl-1">175.5%</span>
                          <span className="text-muted opacity-8 pl-1">
                            increased server resources
                          </span>
                        </div>
                      </div>
                      <ResponsiveContainer height={187}>
                        <AreaChart
                          data={data}
                          margin={{ top: -45, right: 0, left: 0, bottom: 0 }}
                        >
                          <defs>
                            <linearGradient
                              id="colorPv2"
                              x1="0"
                              y1="0"
                              x2="0"
                              y2="1"
                            >
                              <stop
                                offset="10%"
                                stopColor="var(--warning)"
                                stopOpacity={0.7}
                              />
                              <stop
                                offset="90%"
                                stopColor="var(--warning)"
                                stopOpacity={0}
                              />
                            </linearGradient>
                          </defs>
                          <Tooltip />
                          <Area
                            type="monotoneX"
                            dataKey="uv"
                            stroke="var(--warning)"
                            strokeWidth={2}
                            fillOpacity={1}
                            fill="url(#colorPv2)"
                          />
                        </AreaChart>
                      </ResponsiveContainer>
                    </div>
                  </TabPane>
                </Card>
                <Row>
                  <Col lg="6">
                    <div className="card mb-3 widget-chart">
                      <div className="widget-chart-content">
                        <div className="icon-wrapper rounded">
                          <div className="icon-wrapper-bg bg-primary" />
                          <i className="lnr-cog text-primary" />
                        </div>
                        <div className="widget-numbers">45.8k</div>
                        <div className="widget-subheading">Total Views1</div>
                        <div className="widget-description text-success">
                          <FontAwesomeIcon icon={faAngleUp} />
                          <span className="pl-1">175.5%</span>
                        </div>
                      </div>
                      <div className="widget-chart-wrapper chart-wrapper-relative">
                        <ResponsiveContainer height={100}>
                          <LineChart
                            data={data}
                            margin={{ top: 5, right: 5, left: 5, bottom: 0 }}
                          >
                            <Line
                              type="monotone"
                              dataKey="pv"
                              stroke="#3ac47d"
                              strokeWidth={3}
                            />
                          </LineChart>
                        </ResponsiveContainer>
                      </div>
                    </div>
                  </Col>
                  <Col lg="6">
                    <div className="card mb-3 widget-chart">
                      <div className="widget-chart-content">
                        <div className="icon-wrapper rounded">
                          <div className="icon-wrapper-bg bg-danger" />
                          <i className="lnr-laptop-phone text-danger" />
                        </div>
                        <div className="widget-numbers">5.82k</div>
                        <div className="widget-subheading">
                          Reports Submitted
                        </div>
                        <div className="widget-description text-danger">
                          <FontAwesomeIcon icon={faAngleDown} />
                          <span className="pl-1">54.1%</span>
                        </div>
                      </div>
                      <div className="widget-chart-wrapper chart-wrapper-relative">
                        <ResponsiveContainer height={100}>
                          <BarChart data={data}>
                            <Bar
                              dataKey="uv"
                              fill="#81a4ff"
                              stroke="#3f6ad8"
                              strokeWidth={2}
                            />
                          </BarChart>
                        </ResponsiveContainer>
                      </div>
                    </div>
                  </Col>
                </Row>
              </Col>
              <Col md="12" lg="6">
                <Row>

                  {/*******************/}
                  {/* Vulnerabilities */}
                  {/*******************/}

                  <Col md="6">
                    <div className="card mb-3 bg-royal widget-chart text-white card-border">
                      <div className="icon-wrapper rounded">
                        <div className="icon-wrapper-bg bg-white opacity-4" />
                        <i className="lnr-bug icon-gradient bg-white" />
                      </div>
                      <div className="widget-numbers">
                        {this.state.cveTotalCount}
                      </div>
                      <div className="widget-subheading">Vulnerabilities</div>
                      <div className="widget-description text-white">
                        {this.state.cveCountLastYearDifference}
                      </div>
                    </div>
                  </Col>

                  {/**************/}
                  {/* Weaknesses */}
                  {/**************/}

                  <Col md="6">
                    <div className="card mb-3 bg-royal widget-chart text-white card-border">
                      <div className="icon-wrapper rounded">
                        <div className="icon-wrapper-bg bg-white opacity-4" />
                        <i className="lnr-unlink icon-gradient bg-white" />
                      </div>
                      <div className="widget-numbers">{this.state.cweTotalCount}</div>
                      <div className="widget-subheading">Weaknesses</div>
                      <div className="widget-description text-white">
                        <span className="pr-1">As of {timeNow.toLocaleString().split(',')[0]}</span>
                        <br />
                        <span className="pr-1"><a href="#/Weaknesses" className="text-light">More Info</a></span>
                        <FontAwesomeIcon icon={faArrowLeft} />
                      </div>
                    </div>
                  </Col>

                  {/*************/}
                  {/* Platforms */}
                  {/*************/}

                  <Col md="6">
                    <div className="card mb-3 bg-royal widget-chart text-white card-border">
                      <div className="icon-wrapper rounded">
                        <div className="icon-wrapper-bg bg-white opacity-4" />
                        <i className="lnr-tablet text-white" />
                      </div>
                      <div className="widget-numbers">{this.state.cpeTotalCount}</div>
                      <div className="widget-subheading">Platforms</div>
                      {/* <div className="widget-description text-white">
                        <FontAwesomeIcon icon={faArrowRight} />
                        <span className="pl-1">72.1%</span>
                      </div> */}
                    </div>
                  </Col>

                  {/*****************************/}
                  {/* CVE Numbering Authorities */}
                  {/*****************************/}

                  <Col md="6">
                    <div className="card mb-3 bg-royal widget-chart card-border">
                      <div className="widget-chart-content text-white">
                        <div className="icon-wrapper rounded">
                          <div className="icon-wrapper-bg bg-white opacity-4" />
                          <i className="lnr-apartment" />
                        </div>
                        <div className="widget-numbers">{this.state.cnaTotalCount}</div>
                        <div className="widget-subheading">Vulnerability Numbering Authorities</div>
                        {/* <div className="widget-description">
                          <FontAwesomeIcon
                            className="text-white opacity-5"
                            icon={faAngleUp}
                          />
                          <span className="text-white">175.5%</span>
                        </div> */}
                      </div>
                    </div>
                  </Col>


                </Row>
                <div className="card mb-3 widget-chart">
                  <div className="widget-chart-content">
                    <div className="icon-wrapper rounded">
                      <div className="icon-wrapper-bg bg-warning" />
                      <i className="lnr-heart icon-gradient bg-premium-dark">
                        {" "}
                      </i>
                    </div>
                    <div className="widget-numbers">4517.82</div>
                    <div className="widget-subheading">
                      Active Social Profiles
                    </div>
                    <div className="widget-description">
                      Down by
                      <span className="text-danger pl-1 pr-1">
                        <FontAwesomeIcon icon={faAngleDown} />
                        <span className="pl-1">54.1%</span>
                      </span>
                      from 30 days ago
                    </div>
                  </div>
                  <div className="widget-chart-wrapper chart-wrapper-relative">
                    <ResponsiveContainer height={100}>
                      <LineChart
                        data={data2}
                        margin={{ top: 0, right: 5, left: 5, bottom: 0 }}
                      >
                        <Line
                          type="monotone"
                          dataKey="pv"
                          stroke="#d6b5ff"
                          strokeWidth={2}
                        />
                        <Line
                          type="monotone"
                          dataKey="uv"
                          stroke="#a75fff"
                          strokeWidth={2}
                        />
                      </LineChart>
                    </ResponsiveContainer>
                  </div>
                </div>
              </Col>
            </Row>
            <div className="row">
              <div className="col-md-6 col-lg-3">
                <div className="card-shadow-danger mb-3 widget-chart widget-chart2 text-left card">
                  <div className="widget-content">
                    <div className="widget-content-outer">
                      <div className="widget-content-wrapper">
                        <div className="widget-content-left pr-2 fsize-1">
                          <div className="widget-numbers mt-0 fsize-3 text-danger">
                            71%
                          </div>
                        </div>
                        <div className="widget-content-right w-100">
                          <div className="progress-bar-xs progress">
                            <div
                              className="progress-bar bg-danger"
                              role="progressbar"
                              aria-valuenow="71"
                              aria-valuemin="0"
                              aria-valuemax="100"
                              style={{ width: "71%" }}
                            ></div>
                          </div>
                        </div>
                      </div>
                      <div className="widget-content-left fsize-1">
                        <div className="text-muted opacity-6">
                          Income Target
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
              <div className="col-md-6 col-lg-3">
                <div className="card-shadow-success mb-3 widget-chart widget-chart2 text-left card">
                  <div className="widget-content">
                    <div className="widget-content-outer">
                      <div className="widget-content-wrapper">
                        <div className="widget-content-left pr-2 fsize-1">
                          <div className="widget-numbers mt-0 fsize-3 text-success">
                            54%
                          </div>
                        </div>
                        <div className="widget-content-right w-100">
                          <div className="progress-bar-xs progress">
                            <div
                              className="progress-bar bg-success"
                              role="progressbar"
                              aria-valuenow="54"
                              aria-valuemin="0"
                              aria-valuemax="100"
                              style={{ width: "54%" }}
                            ></div>
                          </div>
                        </div>
                      </div>
                      <div className="widget-content-left fsize-1">
                        <div className="text-muted opacity-6">
                          Expenses Target
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
              <div className="col-md-6 col-lg-3">
                <div className="card-shadow-warning mb-3 widget-chart widget-chart2 text-left card">
                  <div className="widget-content">
                    <div className="widget-content-outer">
                      <div className="widget-content-wrapper">
                        <div className="widget-content-left pr-2 fsize-1">
                          <div className="widget-numbers mt-0 fsize-3 text-warning">
                            32%
                          </div>
                        </div>
                        <div className="widget-content-right w-100">
                          <div className="progress-bar-xs progress">
                            <div
                              className="progress-bar bg-warning"
                              role="progressbar"
                              aria-valuenow="32"
                              aria-valuemin="0"
                              aria-valuemax="100"
                              style={{ width: "32%" }}
                            ></div>
                          </div>
                        </div>
                      </div>
                      <div className="widget-content-left fsize-1">
                        <div className="text-muted opacity-6">
                          Spendings Target
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
              <div className="col-md-6 col-lg-3">
                <div className="card-shadow-info mb-3 widget-chart widget-chart2 text-left card">
                  <div className="widget-content">
                    <div className="widget-content-outer">
                      <div className="widget-content-wrapper">
                        <div className="widget-content-left pr-2 fsize-1">
                          <div className="widget-numbers mt-0 fsize-3 text-info">
                            89%
                          </div>
                        </div>
                        <div className="widget-content-right w-100">
                          <div className="progress-bar-xs progress">
                            <div
                              className="progress-bar bg-info"
                              role="progressbar"
                              aria-valuenow="89"
                              aria-valuemin="0"
                              aria-valuemax="100"
                              style={{ width: "89%" }}
                            ></div>
                          </div>
                        </div>
                      </div>
                      <div className="widget-content-left fsize-1">
                        <div className="text-muted opacity-6">
                          Totals Target
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
            <Row>
              <Col md="12">
                <Card className="main-card mb-3">
                  <div className="card-header">
                    Active Users
                    <div className="btn-actions-pane-right">
                      <div role="group" className="btn-group-sm btn-group">
                        <button className="active btn btn-info">
                          Last Week
                        </button>
                        <button className="btn btn-info">All Month</button>
                      </div>
                    </div>
                  </div>
                  <div className="table-responsive">
                    <table className="align-middle mb-0 table table-borderless table-striped table-hover">
                      <thead>
                        <tr>
                          <th className="text-center">#</th>
                          <th>Name</th>
                          <th className="text-center">City</th>
                          <th className="text-center">Status</th>
                          <th className="text-center">Actions</th>
                        </tr>
                      </thead>
                      <tbody>
                        <tr>
                          <td className="text-center text-muted">#345</td>
                          <td>
                            <div className="widget-content p-0">
                              <div className="widget-content-wrapper">
                                <div className="widget-content-left mr-3">
                                  <div className="widget-content-left">
                                    <img
                                      width={40}
                                      className="rounded"
                                      src={avatar4}
                                      alt="Avatar"
                                    />
                                  </div>
                                </div>
                                <div className="widget-content-left flex2">
                                  <div className="widget-heading">John Doe</div>
                                  <div className="widget-subheading opacity-7">
                                    Web Developer
                                  </div>
                                </div>
                              </div>
                            </div>
                          </td>
                          <td className="text-center">Madrid</td>
                          <td className="text-center">
                            <div className="badge badge-warning">Pending</div>
                          </td>
                          <td className="text-center">
                            <button
                              type="button"
                              className="btn btn-primary btn-sm"
                            >
                              Details
                            </button>
                          </td>
                        </tr>
                        <tr>
                          <td className="text-center text-muted">#347</td>
                          <td>
                            <div className="widget-content p-0">
                              <div className="widget-content-wrapper">
                                <div className="widget-content-left mr-3">
                                  <div className="widget-content-left">
                                    <img
                                      width={40}
                                      className="rounded"
                                      src={avatar3}
                                      alt="Avatar"
                                    />
                                  </div>
                                </div>
                                <div className="widget-content-left flex2">
                                  <div className="widget-heading">
                                    Ruben Tillman
                                  </div>
                                  <div className="widget-subheading opacity-7">
                                    Etiam sit amet orci eget
                                  </div>
                                </div>
                              </div>
                            </div>
                          </td>
                          <td className="text-center">Berlin</td>
                          <td className="text-center">
                            <div className="badge badge-success">Completed</div>
                          </td>
                          <td className="text-center">
                            <button
                              type="button"
                              className="btn btn-primary btn-sm"
                            >
                              Details
                            </button>
                          </td>
                        </tr>
                        <tr>
                          <td className="text-center text-muted">#321</td>
                          <td>
                            <div className="widget-content p-0">
                              <div className="widget-content-wrapper">
                                <div className="widget-content-left mr-3">
                                  <div className="widget-content-left">
                                    <img
                                      width={40}
                                      className="rounded"
                                      src={avatar2}
                                      alt="Avatar"
                                    />
                                  </div>
                                </div>
                                <div className="widget-content-left flex2">
                                  <div className="widget-heading">
                                    Elliot Huber
                                  </div>
                                  <div className="widget-subheading opacity-7">
                                    Lorem ipsum dolor sic
                                  </div>
                                </div>
                              </div>
                            </div>
                          </td>
                          <td className="text-center">London</td>
                          <td className="text-center">
                            <div className="badge badge-danger">
                              In Progress
                            </div>
                          </td>
                          <td className="text-center">
                            <button
                              type="button"
                              className="btn btn-primary btn-sm"
                            >
                              Details
                            </button>
                          </td>
                        </tr>
                        <tr>
                          <td className="text-center text-muted">#55</td>
                          <td>
                            <div className="widget-content p-0">
                              <div className="widget-content-wrapper">
                                <div className="widget-content-left mr-3">
                                  <div className="widget-content-left">
                                    <img
                                      width={40}
                                      className="rounded"
                                      src={avatar1}
                                      alt="Avatar"
                                    />
                                  </div>
                                </div>
                                <div className="widget-content-left flex2">
                                  <div className="widget-heading">
                                    Vinnie Wagstaff
                                  </div>
                                  <div className="widget-subheading opacity-7">
                                    UI Designer
                                  </div>
                                </div>
                              </div>
                            </div>
                          </td>
                          <td className="text-center">Amsterdam</td>
                          <td className="text-center">
                            <div className="badge badge-info">On Hold</div>
                          </td>
                          <td className="text-center">
                            <button
                              type="button"
                              className="btn btn-primary btn-sm"
                            >
                              Details
                            </button>
                          </td>
                        </tr>
                      </tbody>
                    </table>
                  </div>
                  <div className="d-block text-center card-footer">
                    <button className="mr-2 btn-icon btn-icon-only btn btn-outline-danger">
                      <i className="pe-7s-trash btn-icon-wrapper"> </i>
                    </button>
                    <button className="btn-wide btn btn-success">Save</button>
                  </div>
                </Card>
              </Col>
            </Row>
            <Row>
              <Col md="4">
                <div className="card mb-3 widget-chart">
                  <div className="widget-chart-content">
                    <div className="icon-wrapper rounded">
                      <div className="icon-wrapper-bg bg-primary" />
                      <i className="lnr-cog text-primary" />
                    </div>
                    <div className="widget-numbers">45.8k</div>
                    <div className="widget-subheading">Total Views3</div>
                    <div className="widget-description text-success">
                      <FontAwesomeIcon icon={faAngleUp} />
                      <span className="pl-1">175.5%</span>
                    </div>
                  </div>
                  <div className="widget-chart-wrapper">
                    <ResponsiveContainer width="100%" aspect={3.0 / 1.0}>
                      <LineChart
                        data={data}
                        margin={{ top: 0, right: 5, left: 5, bottom: 0 }}
                      >
                        <Line
                          type="monotone"
                          dataKey="pv"
                          stroke="#3ac47d"
                          strokeWidth={3}
                        />
                      </LineChart>
                    </ResponsiveContainer>
                  </div>
                </div>
              </Col>
              <Col md="4">
                <div className="card mb-3 widget-chart">
                  <div className="widget-chart-content">
                    <div className="icon-wrapper rounded">
                      <div className="icon-wrapper-bg bg-success" />
                      <i className="lnr-screen text-success" />
                    </div>
                    <div className="widget-numbers">17.2k</div>
                    <div className="widget-subheading">Profiles3</div>
                    <div className="widget-description text-warning">
                      <span className="pr-1">175.5%</span>
                      <FontAwesomeIcon icon={faArrowLeft} />
                    </div>
                  </div>
                  <div className="widget-chart-wrapper">
                    <ResponsiveContainer width="100%" aspect={3.0 / 1.0}>
                      <AreaChart
                        data={data}
                        margin={{ top: 0, right: 0, left: 0, bottom: 0 }}
                      >
                        <Area
                          type="monotoneX"
                          dataKey="uv"
                          stroke="#fd7e14"
                          fill="#ffb87d"
                        />
                      </AreaChart>
                    </ResponsiveContainer>
                  </div>
                </div>
              </Col>
              <Col md="4">
                <div className="card mb-3 widget-chart">
                  <div className="widget-chart-content">
                    <div className="icon-wrapper rounded">
                      <div className="icon-wrapper-bg bg-danger" />
                      <i className="lnr-laptop-phone text-danger" />
                    </div>
                    <div className="widget-numbers">5.82k</div>
                    <div className="widget-subheading">Reports Submitted</div>
                    <div className="widget-description text-danger">
                      <FontAwesomeIcon icon={faAngleDown} />
                      <span className="pl-1">54.1%</span>
                    </div>
                  </div>
                  <div className="widget-chart-wrapper">
                    <ResponsiveContainer width="100%" aspect={3.0 / 1.0}>
                      <BarChart data={data}>
                        <Bar
                          dataKey="uv"
                          fill="#81a4ff"
                          stroke="#3f6ad8"
                          strokeWidth={2}
                        />
                      </BarChart>
                    </ResponsiveContainer>
                  </div>
                </div>
              </Col>
            </Row>
          </div>
        </ReactCSSTransitionGroup>
      </Fragment>
    );
  }
}
