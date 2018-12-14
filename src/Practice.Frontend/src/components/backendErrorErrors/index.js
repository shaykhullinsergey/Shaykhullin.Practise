import React from 'react';
import uuid from 'uuid';
import _isEmpty from 'lodash/isEmpty';
import './BackendErrorMessages.css';

const some = (some) => {
    switch (some) {
        case 'group':
            return 'группе';
        case 'name':
            return 'имени';
        default:
            return null;
    }
};

/**
 * @return {null}
 */
export default function BackendErrorMessages({errorResponse}) {
    console.log(errorResponse);
    return _isEmpty(errorResponse) ? null : (
        <div className="column is-3 backend-error-messages">
            <div className="backend-error-messages__error-title">
                {errorResponse.error}
            </div>
            <ul className="backend-error-messages__error-list">
                {Object.keys(errorResponse).map(field => (
                    <li key={uuid()} className="backend-error-messages__error-item">
                        Ошибка в
                        {' '}
                        {some(field)}
                        .
                        <br/>
                        {' '}
                        {errorResponse[field][0]}
                    </li>
                ))}
            </ul>
        </div>
    );
}
