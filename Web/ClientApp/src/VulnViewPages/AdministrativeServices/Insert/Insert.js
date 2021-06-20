import React from 'react'
import Tabs from 'react-responsive-tabs';
import PageTitle from '../../../Layout/AppMain/PageTitle'
import InsertCVE from './InsertCVE';

const tabsContent = [
    {
        title: 'Vulnerability ',
        content: <InsertCVE />
    },
    // {
    //     title: 'Weakness',
    //     content: <p>Weakness HERE</p>
    // },
    // {
    //     title: 'Platform ',
    //     content: <p>PLAT PLAT HERE</p>
    // },
    // {
    //     title: 'Reference ',
    //     content: <p>REF HERE</p>
    // },
    // {
    //     title: 'Tag',
    //     content: <p>TAG HERE</p>
    // },
];

function getTabs() {
    return tabsContent.map((tab, index) => ({
        title: tab.title,
        getContent: () => tab.content,
        key: index,
    }));
}



export default function Insert() {
    return (
        <div>
            <PageTitle
                heading="Insert Records"
                subheading="Create new records of vulnerabilities, platforms, references, and other types of interest"
                icon="lnr-file-add"
            />

            <Tabs tabsWrapperClass="body-tabs body-tabs-layout" transform={false} showInkBar={true} items={getTabs()} />

        </div>
    )
}
