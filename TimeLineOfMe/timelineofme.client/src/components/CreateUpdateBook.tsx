import type { Book } from "../Models/Book"; 
import type { BookRequest } from "../services/books";
import { useEffect, useState } from "react";

interface Props {
    mode: Mode;
    values: Book;
    isModalOpen: boolean;
    handleCancel: () => void;
    handleCreate: (request: BookRequest) => void;
    handleUpdate: (id: string, request: BookRequest) => void;
}

export enum Mode {
    Create,
    Edit,
}

export const CreateUpdateBook = ({
    mode,
    values,
    isModalOpen,
    handleCancel,
    handleCreate,
    handleUpdate,
}: Props) => {
    const [title, setTitle] = useState<string>("");
    const [description, setDescription] = useState<string>("");
    const [author, setAuthor] = useState<string>("");
    const [publishedDate, setPublishedDate] = useState<string>("");

    useEffect(() => {
        setTitle(values.title);
        setDescription(values.description);
        setAuthor(values.author);
        setPublishedDate(values.publishedDate);
    }, [values]);

    const handleOnOk = async () => {
        const bookRequest = { title, description, author, publishedDate };
        mode == Mode.Create ? handleCreate(bookRequest) : handleUpdate(values.id, bookRequest);
    };

    if (!isModalOpen) return null; // Не рендерим компонент, если модалка закрыта

    return (
        <div className="modal-overlay" onClick={handleCancel}>
            <div className="modal-content" onClick={(e) => e.stopPropagation()}>
                <h2>{mode === Mode.Create ? "Add Book" : "Edit Book"}</h2>
                <div className="book_modal">
                    <input
                        value={title}
                        onChange={(e) => setTitle(e.target.value)}
                        placeholder="Title"
                    />
                    <textarea
                        value={description}
                        onChange={(e) => setDescription(e.target.value)}
                        placeholder="Description"
                    />
                    <input
                        value={author}
                        onChange={(e) => setAuthor(e.target.value)}
                        placeholder="Author"
                    />
                    <input
                        value={publishedDate}
                        onChange={(e) => setPublishedDate(e.target.value)}
                        placeholder="Published Date"
                    />
                    <div>
                        <button onClick={handleOnOk}>
                            {mode === Mode.Create ? "Create" : "Update"}
                        </button>
                        <button onClick={handleCancel}>Cancel</button>
                    </div>
                </div>
            </div>
        </div>
    );
};
