import React from 'react';
import './SelectField.css'; 

const SelectField = ({ label, name, value, onChange, options }) => {
    return (
        <div className="select-field-container">
            <label htmlFor={name} className="select-field-label">
                {label}
            </label>
            <select
                id={name}
                name={name}
                value={value}
                onChange={onChange}
                className="form-control select-field-dropdown"
            >
                <option value="" disabled>
                    Select {label}
                </option>
                {options.map((option) => (
                    <option key={option.value} value={option.value}>
                        {option.label}
                    </option>
                ))}
            </select>
        </div>
    );
};

export default SelectField;