import React from 'react';

const TextInputField = ({ label, name, value, onChange }) => (
    <div className="mb-3">
        <label htmlFor={name} className="form-label">{label}</label>
        <input
            type="text"
            id={name}
            name={name}
            className="form-control"
            value={value}
            onChange={onChange}
        />
    </div>
);

export default TextInputField;