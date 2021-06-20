import React, { Fragment } from 'react';
import { Route } from 'react-router-dom';
import _Weaknesses from './Weaknesses';

// Layout
import AppHeader from '../../../Layout/AppHeader/';
import AppSidebar from '../../../Layout/AppSidebar/';
import AppFooter from '../../../Layout/AppFooter/';

const Weaknesses = ({ match }) => (
    <Fragment>
        <AppHeader />
        <div className="app-main">
            <AppSidebar />
            <div className="app-main__outer">
                <div className="app-main__inner">
                    <_Weaknesses />
                </div>
                <AppFooter />
            </div>
        </div>
    </Fragment>
);

export default Weaknesses;