import React, { useState, useEffect } from 'react';
import TextInputField from '../FormFields/TextInputField';
import TextAreaField from '../FormFields/TextAreaField';
import SelectField from '../FormFields/SelectField';
import { getTicketMetadata } from '../../api/ticketsApi';
import { modules } from '../../constants/modules';

const TicketForm = ({ ticket, onSubmit }) => {
    const [formData, setFormData] = useState({
        title: '',
        description: '',
        priorityId: '',
        module: '',
        urgentLevel: '',
        type: '',
        state: '',
    });

    const [metadata, setMetadata] = useState({
        urgentLevels: [],
        types: [],
        states: [],
    });

    const [loadingMetadata, setLoadingMetadata] = useState(true);

    useEffect(() => {
        const fetchMetadata = async () => {
            try {
                const data = await getTicketMetadata();
                setMetadata(data);
            } catch (error) {
                console.error('Error fetching metadata:', error);
            } finally {
                setLoadingMetadata(false); // Метадані завантажені
            }
        };

        fetchMetadata();
    }, []);

    useEffect(() => {
        if (ticket) setFormData(ticket);
    }, [ticket]);

    const handleChange = (e) => {
        const { name, value } = e.target;
        setFormData({ ...formData, [name]: value });
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        onSubmit(formData);
    };

    if (loadingMetadata) return <p>Loading metadata...</p>; // Покажіть лоадер поки метадані не завантажаться

    return (
        <form onSubmit={handleSubmit}>
            <TextInputField
                label="Title"
                name="title"
                value={formData.title}
                onChange={handleChange}
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
            />
            <SelectField
                label="Urgent Level"
                name="urgentLevel"
                value={formData.urgentLevel}
                onChange={handleChange}
                options={metadata.urgentLevels.map((level) => ({
                    value: level.id,
                    label: level.title,
                }))}
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
            />
            <TextAreaField
                label="Description"
                name="description"
                value={formData.description}
                onChange={handleChange}
            />
            <button type="submit" className="btn btn-success mt-3">
                {ticket ? 'Update Ticket' : 'Create Ticket'}
            </button>
        </form>
    );
};

export default TicketForm;