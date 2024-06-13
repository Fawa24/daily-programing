export default function Input({richText, ...props }) {
    return (
        <input type={richText ? "textarea" : "text"} {...props} />
    )
 } 