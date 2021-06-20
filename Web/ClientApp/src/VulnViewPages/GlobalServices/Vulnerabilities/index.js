import React, { Fragment } from 'react';
import { Route } from 'react-router-dom';
import _Vulnerabilities from './Vulnerabilities';

// Layout
import AppHeader from '../../../Layout/AppHeader/';
import AppSidebar from '../../../Layout/AppSidebar/';
import AppFooter from '../../../Layout/AppFooter/';

const Vulnerabilities = ({ match }) => (
    <Fragment>
        <AppHeader />
        <div className="app-main">
            <AppSidebar />
            <div className="app-main__outer">
                <div className="app-main__inner">
                    <_Vulnerabilities />
                </div>
                <AppFooter />
            </div>
        </div>
    </Fragment>
);

export default Vulnerabilities;