import { BrowserRouter as Router, Route, Redirect } from 'react-router-dom';
import React, { Suspense, lazy, Fragment } from 'react';
import loading from " ../../assets/utils/images/suspense-loading.gif";
import ApiAuthorizationRoutes from '../../components/api-authorization/ApiAuthorizationRoutes';
import AuthorizeRoute from '../../components/api-authorization/AuthorizeRoute';
import { ApplicationPaths } from '../../components/api-authorization/ApiAuthorizationConstants';

import {
    ToastContainer,
} from 'react-toastify';

const Vulnerabilities = lazy(() => import('../../VulnViewPages/GlobalServices/Vulnerabilities'));
const Weaknesses = lazy(() => import('../../VulnViewPages/GlobalServices/Weaknesses'));
const Platforms = lazy(() => import('../../VulnViewPages/GlobalServices/Platforms'));
const Insert = lazy(() => import('../../VulnViewPages/AdministrativeServices/Insert'));
const Remove = lazy(() => import('../../VulnViewPages/AdministrativeServices/Remove'));
const Update = lazy(() => import('../../VulnViewPages/AdministrativeServices/Update'));


const Dashboards = lazy(() => import('../../DemoPages/Dashboards'));
const Widgets = lazy(() => import('../../DemoPages/Widgets'));
const Elements = lazy(() => import('../../DemoPages/Elements'));
const Components = lazy(() => import('../../DemoPages/Components'));
const Charts = lazy(() => import('../../DemoPages/Charts'));
const Forms = lazy(() => import('../../DemoPages/Forms'));
const Tables = lazy(() => import('../../DemoPages/Tables'));

const AppMain = () => {

    return (
        <Fragment>
            {/* Vulnerabilities */}

            <Suspense fallback={
                <div className="loader-container">
                    <div className="loader-container-inner">
                        <img src={loading} />
                    </div>
                </div>
            }>
                <Route path="/Vulnerabilities" component={Vulnerabilities} />
            </Suspense>

            {/* Weaknesses */}

            <Suspense fallback={
                <div className="loader-container">
                    <div className="loader-container-inner">
                        <img src={loading} />
                    </div>
                </div>
            }>
                <Route path="/Weaknesses" component={Weaknesses} />
            </Suspense>


            {/* Platforms */}

            <Suspense fallback={
                <div className="loader-container">
                    <div className="loader-container-inner">
                        <img src={loading} />
                    </div>
                </div>
            }>
                <Route path="/Platforms" component={Platforms} />
            </Suspense>


            {/* Insert */}

            <Suspense fallback={
                <div className="loader-container">
                    <div className="loader-container-inner">
                        <img src={loading} />
                    </div>
                </div>
            }>
                <Route path="/Insert" component={Insert} />
            </Suspense>

            {/* Update */}

            <Suspense fallback={
                <div className="loader-container">
                    <div className="loader-container-inner">
                        <img src={loading} />
                    </div>
                </div>
            }>
                <Route path="/Update" component={Update} />
            </Suspense>


            {/* Remove */}

            <Suspense fallback={
                <div className="loader-container">
                    <div className="loader-container-inner">
                        <img src={loading} />
                    </div>
                </div>
            }>
                <Route path="/Remove" component={Remove} />
            </Suspense>

            {/* DEV */}
            {/* <Suspense fallback={<div>meow</div>}><Route path="/dash" component={Dashboards} /></Suspense>
            <Suspense fallback={<div>meow</div>}><Route path="/form" component={Forms} /></Suspense>
            <Suspense fallback={<div>meow</div>}><Route path="/elem" component={Elements} /></Suspense>
            <Suspense fallback={<div>meow</div>}><Route path="/comp" component={Components} /></Suspense>
            <Suspense fallback={<div>meow</div>}><Route path="/tab" component={Tables} /></Suspense> */}

            {/* Default */}
            <Route exact path="/index.html" render={() => <Redirect to="/Vulnerabilities" />} />
            <Route exact path="/" render={() => <Redirect to="/Vulnerabilities" />} />
            <Route path={ApplicationPaths.ApiAuthorizationPrefix} component={ApiAuthorizationRoutes} />

            <ToastContainer />
        </Fragment>
    )
};

export default AppMain;