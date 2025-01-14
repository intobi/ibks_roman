import React, { useState, useEffect } from 'react';
import TextInputField from '../FormFields/TextInputField';
import TextAreaField from '../FormFields/TextAreaField';
import SelectField from '../FormFields/SelectField';
import { getTicketMetadata } from '../../api/ticketsApi';
import { modules } from '../../constants/modules';

const TicketForm = ({ ticket, metadata, onChange }) => {
    const [formData, setFormData] = useState({
        title: '',
        description: '',
        module: '',
        lvl: '',
        type: '',
        state: '',
    });

    const handleChange = (e) => {
        const { name, value } = e.target;
        const updatedFields = { [name]: value };
        setFormData((prev) => ({ ...prev, ...updatedFields }));
        onChange(updatedFields);
    };


    const isFieldValid = (value) => {
        if (typeof value === "string") {
            return value.trim() !== "";
        }
        return value !== null && value !== undefined;
    };

    useEffect(() => {
        if (ticket) setFormData(ticket);
    }, [ticket]);

    return (
        <form>
            <TextInputField
                label="Title"
                name="title"
                value={formData.title}
                onChange={handleChange}
                class={!isFieldValid(formData.title) ? 'is-invalid' : ''}
            />
            <SelectField
                label="Module"
                name="module"
                value={formData.module}
                onChange={handleChange}
                options={modules.map((module) => ({
                    value: module.id,
                    label: module.title,
                }))}
                className={!isFieldValid(formData.module) ? 'is-invalid' : ''}
            />
            <SelectField
                label="Urgent Level"
                name="lvl"
                value={formData.lvl}
                onChange={handleChange}
                options={metadata.urgentLevels.map((level) => ({
                    value: level.id,
                    label: level.title,
                }))}
                className={!isFieldValid(formData.lvl) ? 'is-invalid' : ''}
            />
            <SelectField
                label="Type"
                name="type"
                value={formData.type}
                onChange={handleChange}
                options={metadata.types.map((type) => ({
                    value: type.id,
                    label: type.title,
                }))}
                className={!isFieldValid(formData.type) ? 'is-invalid' : ''}
            />
            <SelectField
                label="State"
                name="state"
                value={formData.state}
                onChange={handleChange}
                options={metadata.states.map((state) => ({
                    value: state.id,
                    label: state.title,
                }))}
                className={!isFieldValid(formData.state) ? 'is-invalid' : ''}
            />
            <TextAreaField
                label="Description"
                name="description"
                value={formData.description}
                onChange={handleChange}
                className={!isFieldValid(formData.description) ? 'is-invalid' : ''}
            />
        </form>
    );
};

export default TicketForm;