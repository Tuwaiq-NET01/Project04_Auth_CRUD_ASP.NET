import React, { Fragment } from 'react';
import { Route } from 'react-router-dom';
import _Platforms from './Platforms';

// Layout
import AppHeader from '../../../Layout/AppHeader/';
import AppSidebar from '../../../Layout/AppSidebar/';
import AppFooter from '../../../Layout/AppFooter/';

const Platforms = ({ match }) => (
    <Fragment>
        <AppHeader />
        <div className="app-main">
            <AppSidebar />
            <div className="app-main__outer">
                <div className="app-main__inner">
                    <_Platforms />
                </div>
                <AppFooter />
            </div>
        </div>
    </Fragment>
);

export default Platforms;