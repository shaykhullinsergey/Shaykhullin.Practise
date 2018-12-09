import React from 'react';

const AuthTemplate = ({formData: {name, group}, formErrors, onChange, onSubmit}) => {
    return (
        <div style={{position:'absolute'}} className="columns is-fullheight is-fullwidth is-centered is-vcentered">
            <form className="column is-4" action="submit">
                <h2 className="title has-text-centered">The Education Recourse</h2>
                <label className="label" htmlFor="name">
                    Name
                    <input className="input" value={name} name="name" onChange={({target}) => onChange(target)}
                           type="text"/>
                </label>
                <label className="label" htmlFor="group">
                    Group
                    <input className="input" value={group} name="group"
                           onChange={({target}) => onChange(target)}
                           type="text"/>
                </label>
                <button type="button" className="button is-fullwidth is-link" onClick={onSubmit}>Submit</button>
            </form>
        </div>
    );
};

export default AuthTemplate;
