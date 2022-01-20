using SendGrid.Helpers.Mail;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SendGridHttpFunction.Converters
{
    public class AttachmentConverter : JsonConverter<Attachment>
    {
        public override Attachment? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            // to do: Implement READ as needed.
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, Attachment value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            writer.WriteString(options.PropertyNamingPolicy?.ConvertName(nameof(value.Content)) ?? nameof(value.Content), value.Content);
            writer.WriteString(options.PropertyNamingPolicy?.ConvertName(nameof(value.Type)) ?? nameof(value.Type), value.Type);
            writer.WriteString(options.PropertyNamingPolicy?.ConvertName(nameof(value.Filename)) ?? nameof(value.Filename), value.Filename);
            writer.WriteString(options.PropertyNamingPolicy?.ConvertName(nameof(value.Disposition)) ?? nameof(value.Disposition), value.Disposition);
            writer.WriteString(options.PropertyNamingPolicy?.ConvertName("content_id") ?? "content_id", value.ContentId);

            writer.WriteEndObject();
        }
    }

    public class SendGridMessageConverter : JsonConverter<SendGridMessage>
    {
        public override SendGridMessage? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            // to do: Implement READ as needed.
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, SendGridMessage value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            writer.WritePropertyName(options.PropertyNamingPolicy?.ConvertName(nameof(value.From)) ?? nameof(value.From));
            //WriteProperty(writer, value.From, _from, options);
            JsonSerializer.Serialize(writer, value.From, options);

            writer.WriteString(options.PropertyNamingPolicy?.ConvertName(nameof(value.Subject)) ?? nameof(value.Subject), value.Subject);

            writer.WritePropertyName(options.PropertyNamingPolicy?.ConvertName(nameof(value.Personalizations)) ?? nameof(value.Personalizations));

            //writer.WriteStartArray();
            JsonSerializer.Serialize(writer, value.Personalizations, options);
            //writer.WriteEndArray();

            writer.WritePropertyName(options.PropertyNamingPolicy?.ConvertName("content") ?? "content");
            JsonSerializer.Serialize(writer, value.Contents, options);

            writer.WritePropertyName(options.PropertyNamingPolicy?.ConvertName(nameof(value.Attachments)) ?? nameof(value.Attachments));
            JsonSerializer.Serialize(writer, value.Attachments, options);

            writer.WriteString(options.PropertyNamingPolicy?.ConvertName("template_id") ?? "template_id", value.TemplateId);

            writer.WritePropertyName(options.PropertyNamingPolicy?.ConvertName(nameof(value.Headers)) ?? nameof(value.Headers));
            JsonSerializer.Serialize(writer, value.Headers, options);

            writer.WritePropertyName(options.PropertyNamingPolicy?.ConvertName(nameof(value.Sections)) ?? nameof(value.Sections));
            JsonSerializer.Serialize(writer, value.Sections, options);

            writer.WritePropertyName(options.PropertyNamingPolicy?.ConvertName(nameof(value.Categories)) ?? nameof(value.Categories));
            JsonSerializer.Serialize(writer, value.Categories, options);

            writer.WritePropertyName(options.PropertyNamingPolicy?.ConvertName("custom_args") ?? "custom_args");
            JsonSerializer.Serialize(writer, value.CustomArgs, options);

            writer.WritePropertyName(options.PropertyNamingPolicy?.ConvertName("send_at") ?? "send_at");
            JsonSerializer.Serialize(writer, value.SendAt, options);

            writer.WritePropertyName(options.PropertyNamingPolicy?.ConvertName(nameof(value.Asm)) ?? nameof(value.Asm));
            JsonSerializer.Serialize(writer, value.Asm, options);

            writer.WriteString(options.PropertyNamingPolicy?.ConvertName("batch_id") ?? "batch_id", value.BatchId);

            writer.WriteString(options.PropertyNamingPolicy?.ConvertName("ip_pool_name") ?? "ip_pool_name", value.IpPoolName);

            writer.WritePropertyName(options.PropertyNamingPolicy?.ConvertName("mail_settings") ?? "mail_settings");
            JsonSerializer.Serialize(writer, value.MailSettings, options);

            writer.WritePropertyName(options.PropertyNamingPolicy?.ConvertName("tracking_settings") ?? "tracking_settings");
            JsonSerializer.Serialize(writer, value.TrackingSettings, options);

            writer.WritePropertyName(options.PropertyNamingPolicy?.ConvertName("reply_to") ?? "reply_to");
            JsonSerializer.Serialize(writer, value.ReplyTo, options);

            writer.WriteEndObject();
        }
    }

    public class PersonalizationConverter : JsonConverter<Personalization>
    {
        public override Personalization Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            // to do: Implement READ as needed.
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, Personalization value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            writer.WritePropertyName("to");
            JsonSerializer.Serialize(writer, value.Tos, options);

            writer.WritePropertyName(options.PropertyNamingPolicy?.ConvertName("cc") ?? "cc");
            JsonSerializer.Serialize(writer, value.Ccs, options);

            writer.WritePropertyName(options.PropertyNamingPolicy?.ConvertName("bcc") ?? "bcc");
            JsonSerializer.Serialize(writer, value.Bccs, options);

            writer.WritePropertyName(options.PropertyNamingPolicy?.ConvertName(nameof(value.From)) ?? nameof(value.From));
            JsonSerializer.Serialize(writer, value.From, options);

            writer.WriteString(options.PropertyNamingPolicy?.ConvertName(nameof(value.Subject)) ?? nameof(value.Subject), value.Subject);

            writer.WritePropertyName(options.PropertyNamingPolicy?.ConvertName(nameof(value.Headers)) ?? nameof(value.Headers));
            JsonSerializer.Serialize(writer, value.Headers, options);

            writer.WritePropertyName(options.PropertyNamingPolicy?.ConvertName(nameof(value.Substitutions)) ?? nameof(value.Substitutions));
            JsonSerializer.Serialize(writer, value.Substitutions, options);

            writer.WritePropertyName(options.PropertyNamingPolicy?.ConvertName("custom_args") ?? "custom_args");
            JsonSerializer.Serialize(writer, value.CustomArgs, options);

            writer.WritePropertyName(options.PropertyNamingPolicy?.ConvertName("send_at") ?? "send_at");
            JsonSerializer.Serialize(writer, value.SendAt, options);

            writer.WritePropertyName(options.PropertyNamingPolicy?.ConvertName("dynamic_template_data") ?? "dynamic_template_data");
            JsonSerializer.Serialize(writer, value.TemplateData, options);

            writer.WriteEndObject();
        }
    }
}
