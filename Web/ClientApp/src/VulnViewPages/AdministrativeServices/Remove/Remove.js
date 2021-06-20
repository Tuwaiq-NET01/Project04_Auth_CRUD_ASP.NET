import React from 'react'
import Tabs from 'react-responsive-tabs';
import PageTitle from '../../../Layout/AppMain/PageTitle'
import RemoveCVE from './RemoveCVE';

const tabsContent = [
    {
        title: 'Vulnerability ',
        content: <RemoveCVE />
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



export default function Remove() {
    return (
        <div>
            <PageTitle
                heading="Remove Records"
                subheading="Remove records of vulnerabilities, platforms, references, and other types of interest"
                icon="fas fa-trash-alt"
            />

            <Tabs tabsWrapperClass="body-tabs body-tabs-layout" transform={false} showInkBar={true} items={getTabs()} />

        </div>
    )
}
