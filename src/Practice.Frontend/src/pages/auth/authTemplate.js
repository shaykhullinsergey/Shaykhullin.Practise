import React from 'react';
import _isEmpty from 'lodash/isEmpty';
import BackendErrorMessages from "../../components/backendErrorErrors";

const AuthTemplate = ({formData: {name, group}, formErrors, onChange, onSubmit}) => {
    return (
        <div style={{position: 'absolute', display: 'flex', flexDirection: 'column'}}
             className="columns is-fullheight is-fullwidth is-centered is-vcentered">
            <form className="column is-3" action="submit">
                <h2 className="title has-text-centered">The Education Recourse</h2>
                <label className="label" htmlFor="name">
                    Имя
                    <input className="input" value={name} name="name" onChange={({target}) => onChange(target)}
                           type="text"/>
                </label>
                <label className="label" htmlFor="group">
                    Группа
                    <input className="input" value={group} name="group"
                           onChange={({target}) => onChange(target)}
                           type="text"/>
                </label>
                <button type="button" className="button is-fullwidth is-link" onClick={onSubmit}>Войти</button>
            </form>
            {!_isEmpty(formErrors) && <BackendErrorMessages errorResponse={formErrors}/>}
        </div>
    );
};

export default AuthTemplate;
