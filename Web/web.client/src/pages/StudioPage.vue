<template>
	<div class="editor__container">
		<div class="editor__buttons">
			<input type="file" ref="fileInput" style="display: none" @change="onFileSelected">
			<my-button @click="save">Сохранить</my-button>
			<my-button @click="extractFromFile">Извлечь из файла</my-button>
		</div>
		<vue-monaco-editor
			v-model:value="workflow.script"
			:language="'csharp'"
			:options="MONACO_EDITOR_OPTIONS"
			class="editor"
			@mount="handleMount"
		/>
	</div>
</template>

<script setup>
import {shallowRef} from 'vue'

const MONACO_EDITOR_OPTIONS = {
	automaticLayout: true,
	formatOnType: true,
	formatOnPaste: true,
}

const editorRef = shallowRef()
const handleMount = editor => (editorRef.value = editor)
</script>

<script>
import MyButton from "@/components/UI/MyButton.vue";
import VueMonacoEditor from "@guolao/vue-monaco-editor";
import axios from "axios";

export default {
	components: {MyButton, VueMonacoEditor},
	data() {
		return {
			workflow: {},
			isWorkflowLoading: false,
		}
	},
	methods: {
		extractFromFile() {
			this.$refs.fileInput.click();
		},
		onFileSelected(event) {
			const file = event.target.files[0];
			if (file) {
				const reader = new FileReader();
				reader.onload = (e) => {
					this.workflow.script = e.target.result;
				};
				reader.readAsText(file);
			}
		},
		async save() {
			if (confirm("Сохранить изменения?")) {
				await axios.put(`/api/Workflows/Update/${this.workflow.id}`, this.workflow);
				this.$router.push('/workflows');
			}
		},
		async fetchWorkflow(id) {
			try {
				this.isWorkflowLoading = true;
				const response = await axios.get(`/api/Workflows/Get/${id}`);
				this.workflow = response.data;
				if (!this.workflow.script || this.workflow.script === '') {
					this.workflow.script = `using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;

public class Script : IScript
{
	public void Perform(DesktopSession desktopSession)
	{
		//Enter your code here...
	}
}`;
				}
			} catch (e) {
				alert(`An error occurred: ${e}`);
				console.log(e);
			} finally {
				this.isWorkflowLoading = false;
			}
		}
	},
	mounted() {
		this.fetchWorkflow(this.$route.params.id);
	}
}
</script>

<style scoped>
.editor__container {
	width: 100%;
	height: calc(100vh - 150px);
}

.editor__buttons {
	display: flex;
	justify-content: flex-end;
	gap: 1rem;
}

.editor {
	margin-top: 15px;
	border: 1px solid #ddd;
	height: 100%;
	border-radius: 2px;
}

</style>